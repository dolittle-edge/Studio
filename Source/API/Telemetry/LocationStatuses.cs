/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.Collections;
using Dolittle.IO;
using Dolittle.Lifecycle;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;
using Read.Locations;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an implementation of <see cref="ILocationStatuses"/>
    /// </summary>
    [Singleton]
    public class LocationStatuses : ILocationStatuses
    {
        static readonly TimeSpan _threshold = TimeSpan.FromMinutes(2);

        readonly ConcurrentDictionary<TenantId, ConcurrentDictionary<LocationId, LocationWithStatus>>  _statusesPerTenant = new ConcurrentDictionary<TenantId, ConcurrentDictionary<LocationId, LocationWithStatus>>();
        readonly ConcurrentDictionary<LocationId, ConcurrentDictionary<NodeId, DateTimeOffset>> _nodesLastSeenByLocation = new ConcurrentDictionary<LocationId, ConcurrentDictionary<NodeId, DateTimeOffset>>();
        private readonly ISerializer _serializer;
        private readonly IFileSystem _fileSystem;

        async Task UpdateStatuses()
        {
            for(;;)
            {
                
                Parallel.ForEach(_statusesPerTenant.Keys, tenantId =>
                {
                    MakeSureTenantExists(tenantId);
                    var statuses = _statusesPerTenant[tenantId];
                    Parallel.ForEach(statuses.Keys, locationId => UpdateConnectedNodesFor(tenantId, locationId));
                });

                await Task.Delay(5000);
            }
        }

        void UpdateConnectedNodesFor(TenantId tenantId, LocationId locationId)
        {          
            var now = DateTimeOffset.UtcNow;
            MakeSureLastSeenByLocationForNodesEists(locationId);
            var connected = _nodesLastSeenByLocation[locationId].Values.Count(_ => now.Subtract(_) <= _threshold);
            _statusesPerTenant[tenantId][locationId].ConnectedNodes = connected;
            if( _nodesLastSeenByLocation[locationId].Values.Count() > 0 )
                _statusesPerTenant[tenantId][locationId].LastSeen = _nodesLastSeenByLocation[locationId].Values.OrderByDescending(_ => _).First();
        }


        /// <summary>
        /// Initializes a new instance of <see cref="LocationStatuses"/>
        /// </summary>
        /// <param name="serializer">JSON <see cref="ISerializer"/></param>
        /// <param name="fileSystem"><see cref="IFileSystem"/> to use</param>
        public LocationStatuses(
            ISerializer serializer,
            IFileSystem fileSystem)
        {
            _serializer = serializer;
            _fileSystem = fileSystem;
            Task.Run(async () => await UpdateStatuses());
        }


        /// <inheritdoc/>
        public void Initialize()
        {
            
        }


        /// <inheritdoc/>
        public IEnumerable<LocationWithStatus> GetFor(TenantId tenantId)
        {
            MakeSureTenantExists(tenantId);
            return _statusesPerTenant[tenantId].Values;
        }

        /// <inheritdoc/>
        public void ReportConnectionFrom(LocationId locationId, NodeId nodeId)
        {
            var tenantId = TenantId.Development;

            MakeSureTenantExists(tenantId);

            if (!_statusesPerTenant.ContainsKey(tenantId))
                _statusesPerTenant[tenantId] = new ConcurrentDictionary<LocationId, LocationWithStatus>();

            var statuses = _statusesPerTenant[tenantId];
            if (!statuses.ContainsKey(locationId))
                statuses[locationId] = new LocationWithStatus
                {
                    Id = locationId,
                };

            var now = DateTimeOffset.UtcNow;

            MakeSureLastSeenByLocationForNodesEists(locationId);

            _nodesLastSeenByLocation[locationId][nodeId] = now;

            UpdateConnectedNodesFor(tenantId, locationId);
            WriteStatusFile(tenantId);
        }

        void MakeSureLastSeenByLocationForNodesEists(LocationId locationId)
        {
            if (!_nodesLastSeenByLocation.ContainsKey(locationId))
                _nodesLastSeenByLocation[locationId] = new ConcurrentDictionary<NodeId, DateTimeOffset>();
        }

        void MakeSureTenantExists(TenantId tenantId)
        {
            if( !_statusesPerTenant.ContainsKey(tenantId) )
                ReadStatusFileFor(tenantId);
        }

        void ReadStatusFileFor(TenantId tenantId)
        {
            var tenantPath = Path.Combine("Data", tenantId.ToString());
            var locationsFile = Path.Combine(tenantPath, "locations_with_status.json");
            var json = _fileSystem.ReadAllText(locationsFile);
            var statuses = _serializer.FromJson<LocationWithStatus[]>(json);
            _statusesPerTenant[tenantId] = new ConcurrentDictionary<LocationId, LocationWithStatus>();
            statuses.ForEach(_ => _statusesPerTenant[tenantId][_.Id] = _);
        }

        void WriteStatusFile(TenantId tenantId)
        {
            var tenantPath = Path.Combine("Data", tenantId.ToString());
            var locationsFile = Path.Combine(tenantPath, "locations_with_status.json");
            var json = _serializer.ToJson(_statusesPerTenant[tenantId].Values, SerializationOptions.CamelCase);
            _fileSystem.WriteAllText(locationsFile, json);
        }
    }
}