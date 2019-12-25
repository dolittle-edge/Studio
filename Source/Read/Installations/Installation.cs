// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    /// <summary>
    /// Represents an installation at a site.
    /// </summary>
    public class Installation : IReadModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for a node.
        /// </summary>
        public InstallationId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the node.
        /// </summary>
        public InstallationName Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the node.
        /// </summary>
        public SiteId SiteId { get; set; }
    }
}