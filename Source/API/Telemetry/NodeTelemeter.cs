/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Concepts.Telemetry;
using Dolittle.Collections;
using Dolittle.Execution;
using Dolittle.IO;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;
using Read.Locations;
using Read.Locations.Nodes;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an implementation of <see cref="INodeTelemeter"/>
    /// </summary>
    [SingletonPerTenant]
    public class NodeTelemeter : INodeTelemeter
    {
        readonly IExecutionContextManager _executionContextManager;
        readonly ISerializer _serializer;
        readonly Dictionary<LocationId, LocationStatus> _statusByLocation = new Dictionary<LocationId, LocationStatus>();
        readonly IFileSystem _fileSystem;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="NodeTelemeter"/>
        /// </summary>
        /// <param name="executionContextManager"><see cref="IExecutionContextManager"/> to use for getting current <see cref="ExecutionContext"/></param>
        /// <param name="fileSystem"></param>
        /// <param name="serializer">JSON <see cref="ISerializer"/></param>
        /// <param name="logger"></param>
        public NodeTelemeter(
            IExecutionContextManager executionContextManager,
            IFileSystem fileSystem,
            ISerializer serializer,
            ILogger logger)
        {
            _executionContextManager = executionContextManager;
            _serializer = serializer;
            _fileSystem = fileSystem;
            _logger = logger;
            PopulateStatusesFromLocations();
        }

        /// <inheritdoc/>
        public bool HasStatusFor(LocationName name)
        {
            PopulateStatusesFromLocationsIfThereAreNone();
            _logger.Information($"Checkinf if we have status for '{name}'");
            _statusByLocation.Values.ForEach(_ => _logger.Information($"  Location : {_.Name}"));
            return _statusByLocation.Values.Any(_ => _.Name.Value.ToLowerInvariant() == name.Value.ToLowerInvariant());
        }

        /// <inheritdoc/>
        public bool HasStatusFor(LocationId locationId)
        {
            PopulateStatusesFromLocationsIfThereAreNone();
            MakeSureLocationStatusExistsFor(locationId);
            return _statusByLocation.ContainsKey(locationId);
        }

        /// <inheritdoc/>
        public LocationStatus GetStatusFor(LocationName name)
        {
            PopulateStatusesFromLocationsIfThereAreNone();
            return _statusByLocation.Values.SingleOrDefault(_ => _.Name.Value.ToLowerInvariant() == name.Value.ToLowerInvariant());
        }

        /// <inheritdoc/>
        public LocationStatus GetStatusFor(LocationId locationId)
        {
            return _statusByLocation[locationId];
        }

        /// <inheritdoc/>
        public void Transmit(LocationId locationId, NodeId nodeId, IDictionary<TelemetryType, TelemetrySample> state)
        {
            var status = MakeSureLocationStatusExistsFor(locationId);
            if (status != null)
            {
                var node = status.Nodes.SingleOrDefault(_ => _.Id == nodeId);
                if (node != null)
                {
                    foreach ((var key, var value) in state) node.State[key] = value;

                    node.LastUpdated = DateTimeOffset.UtcNow;
                }
                WriteLocationStatus(locationId);
            }
        }

        LocationStatus MakeSureLocationStatusExistsFor(LocationId locationId)
        {
            if (_statusByLocation.ContainsKey(locationId)) return _statusByLocation[locationId];
            var statusFilePath = GetStatusFilePath(locationId);
            _logger.Information($"Status file path : '{statusFilePath}'");
            if (_fileSystem.Exists(statusFilePath))
            {
                _logger.Information($"Exists");
                var json = _fileSystem.ReadAllText(statusFilePath);
                var status = _serializer.FromJson<LocationStatus>(json);
                _statusByLocation[locationId] = status;
                return status;
            }
            else
            {
                _logger.Information($"Doesn't exist");
                var status = new LocationStatus();
                var locationPath = GetLocationPath(locationId);
                var nodesFile = Path.Combine(locationPath, "nodes.json");
                if (_fileSystem.Exists(nodesFile))
                {

                    var json = _fileSystem.ReadAllText(nodesFile);
                    var nodes = _serializer.FromJson<Node[]>(json);
                    status.Nodes = nodes.Select(_ =>
                        new NodeStatus
                        {
                            Id = _.Id,
                                Name = _.Name,
                                State = new Dictionary<TelemetryType, TelemetrySample>(),
                                Connectivity = Connectivity.Disconnected,
                                LastUpdated = DateTimeOffset.MinValue
                        }
                    );
                }
                else
                {
                    status.Nodes = new NodeStatus[0];
                }

                _statusByLocation[locationId] = status;
                WriteLocationStatus(locationId);
                return status;
            }
        }

        void WriteLocationStatus(LocationId locationId)
        {
            var statusFilePath = GetStatusFilePath(locationId);
            _fileSystem.WriteAllText(
                statusFilePath,
                _serializer.ToJson(
                    _statusByLocation[locationId],
                    SerializationOptions.CamelCase
                )
            );
        }
        
        string GetLocationsFilePath()
        {
            var tenantPath = GetTenantPath();
            var locationsFile = Path.Combine(tenantPath, "locations.json");
            return locationsFile;
        }

        string GetStatusFilePath(LocationId locationId)
        {
            var locationPath = GetLocationPath(locationId);
            var statusFile = Path.Combine(locationPath, "status.json");
            return statusFile;
        }

        string GetLocationPath(LocationId locationId)
        {
            var tenantPath = GetTenantPath();
            var locationPath = Path.Combine(tenantPath, locationId.ToString());
            return locationPath;
        }

        string GetTenantPath()
        {
            //var tenant = _executionContextManager.Current.Tenant;
            var tenant = TenantId.Development;
            var tenantPath = Path.Combine("Data", tenant.ToString());
            return tenantPath;
        }

        void PopulateStatusesFromLocationsIfThereAreNone()
        {
            if( _statusByLocation.Count == 0 ) PopulateStatusesFromLocations();
        }

        void PopulateStatusesFromLocations()
        {
            var locationsFile = GetLocationsFilePath();
            if( _fileSystem.Exists(locationsFile))
            {
                _logger.Information($"Reading locations from '{locationsFile}'");
                var json = _fileSystem.ReadAllText(locationsFile);
                _logger.Information($"  Content : '{json}'");
                var locations = _serializer.FromJson<Location[]>(json);
                locations.ForEach(_ => 
                {
                    _logger.Information($"Make sure location status exists for '{_.Name}'");
                    MakeSureLocationStatusExistsFor(_.Id);
                });
            } 
        }
    }
}