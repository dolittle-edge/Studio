// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace API.Provisioning
{
    /// <summary>
    /// Represents the provisioning status of a node.
    /// </summary>
    public enum ProvisioningStatus
    {
        /// <summary>
        /// The node is unknown or not yet configured
        /// </summary>
        NotConfigured,

        /// <summary>
        /// The node has been configured
        /// </summary>
        Configured,

        /// <summary>
        /// The node configuration has been revoked, and should be deleted by the Edge Agent
        /// </summary>
        Revoked
    }
}