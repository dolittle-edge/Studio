// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Concepts.Installations;

namespace API.Provisioning
{
    /// <summary>
    /// Defines a provider for Edge Agent configurations and provisioning statuses.
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Checks the current provisioning status for a node identified by its <see cref="SystemInformation"/>.
        /// </summary>
        /// <param name="information"><see cref="SystemInformation"/> identifying the node.</param>
        /// <returns><see cref="ProvisioningStatus"/> for the node.</returns>
        ProvisioningStatus GetProvisioningStatusForNode(SystemInformation information);

        /// <summary>
        /// Checks the current provisioning status for a node identified by its <see cref="NodeId"/>.
        /// </summary>
        /// <param name="nodeId"><see cref="NodeId"/> identifying the node.</param>
        /// <returns><see cref="ProvisioningStatus"/> for the node.</returns>
        ProvisioningStatus GetProvisioningStatusForNodeById(NodeId nodeId);

        /// <summary>
        /// Gets the current configuration for a node identified by its <see cref="SystemInformation"/>.
        /// </summary>
        /// <param name="information"><see cref="SystemInformation"/> identifying the node.</param>
        /// <returns><see cref="NodeConfiguration"/> for the node.</returns>
        NodeConfiguration GetConfigurationForNode(SystemInformation information);

        /// <summary>
        /// Gets the current configuration for a node identified by its <see cref="NodeId"/>.
        /// </summary>
        /// <param name="nodeId"><see cref="NodeId"/> identifying the node.</param>
        /// <returns><see cref="NodeConfiguration"/> for the node.</returns>
        NodeConfiguration GetConfigurationForNodeById(NodeId nodeId);
    }
}