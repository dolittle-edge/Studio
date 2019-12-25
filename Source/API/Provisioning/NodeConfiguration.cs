// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Concepts.Installations;

namespace API.Provisioning
{
    /// <summary>
    /// Represents configuration for the EdgeAgent on a node.
    /// </summary>
    public class NodeConfiguration
    {
        /// <summary>
        /// Gets or sets the unique identifier for the site where the installation is.
        /// </summary>
        public SiteId SiteId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the installation which the node is associated with.
        /// </summary>
        public InstallationId InstallationId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the node.
        /// </summary>
        public NodeId NodeId { get; set; }

        /// <summary>
        /// Gets or sets the configurations for the Edge Agent to apply to low-level systems on the node.
        /// </summary>
        public IDictionary<string, object> Configuration { get; set; }

        /// <summary>
        /// Gets or sets the token used for API calls.
        /// </summary>
        public string Token { get; set; }
    }
}