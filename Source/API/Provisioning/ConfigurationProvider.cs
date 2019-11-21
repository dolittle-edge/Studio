/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.IO;
using Concepts.Installations;
using Dolittle.IO;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;

namespace API.Provisioning
{
    /// <summary>
    /// An implementation of <see cref="IConfigurationProvider"/>
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider
    {
        readonly ISerializer _serializer;
        readonly IFileSystem _fileSystem;

        /// <summary>
        /// Creates an instance of <see cref="ConfigurationProvider"/>
        /// </summary>
        public ConfigurationProvider(ISerializer serializer, IFileSystem fileSystem)
        {
            _serializer = serializer;
            _fileSystem = fileSystem;
        }

        /// <inheritdoc/>
        public ProvisioningStatus GetProvisioningStatusForNode(SystemInformation information)
        {
            if (NodeConfigurationFileExists(information))
            {
                return ProvisioningStatus.Configured;
            }
            return ProvisioningStatus.NotConfigured;
        }

        /// <inheritdoc/>
        public NodeConfiguration GetConfigurationForNode(SystemInformation information)
        {
            if (!NodeConfigurationFileExists(information))
            {
                throw new NodeConfigurationFileDoesNotExist(PathForNodeConfiguration(information));
            }
            return ReadConfigurationFileFor(information);
        }

        string PathForNodeConfiguration(SystemInformation information)
        {
            var tenantId = TenantId.Development;
            return Path.Combine("Data", tenantId.ToString(), "configurations", $"{information.SerialNumber}.json");
        }

        bool NodeConfigurationFileExists(SystemInformation information)
        {
            return _fileSystem.Exists(PathForNodeConfiguration(information));
        }

        NodeConfiguration ReadConfigurationFileFor(SystemInformation information)
        {
            var json = _fileSystem.ReadAllText(PathForNodeConfiguration(information));
            return _serializer.FromJson<NodeConfiguration>(json);
        }



        /// <inheritdoc />
        public ProvisioningStatus GetProvisioningStatusForNodeById(NodeId nodeId)
        {
            if (HasConfigurationForNodeId(nodeId))
            {
                return ProvisioningStatus.Configured;
            }
            return ProvisioningStatus.NotConfigured;
        }

        /// <inheritdoc />
        public NodeConfiguration GetConfigurationForNodeById(NodeId nodeId)
        {
            return ReadConfigurationForNodeId(nodeId);
        }

        bool HasConfigurationForNodeId(NodeId nodeId)
        {
            var tenantId = TenantId.Development;
            var configurationsPath = Path.Combine("Data", tenantId.ToString(), "configurations");
            foreach (var file in _fileSystem.GetFilesFrom(configurationsPath, "*.json"))
            {
                var json = _fileSystem.ReadAllText(file.FullName);
                var config = _serializer.FromJson<NodeConfiguration>(json);
                if (config.NodeId.Equals(nodeId))
                {
                    return true;
                }
            }
            return false;
        }

        NodeConfiguration ReadConfigurationForNodeId(NodeId nodeId)
        {
            var tenantId = TenantId.Development;
            var configurationsPath = Path.Combine("Data", tenantId.ToString(), "configurations");
            foreach (var file in _fileSystem.GetFilesFrom(configurationsPath, "*.json"))
            {
                var json = _fileSystem.ReadAllText(file.FullName);
                var config = _serializer.FromJson<NodeConfiguration>(json);
                if (config.NodeId.Equals(nodeId))
                {
                    return config;
                }
            }
            throw new NodeConfigurationFileDoesNotExist("?");
        }
    }
}