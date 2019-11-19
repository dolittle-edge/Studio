/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    /// <summary>
    /// Represents a node at a location
    /// </summary>
    public class Installation : IReadModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for a node
        /// </summary>
        public InstallationId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the node
        /// </summary>
        public InstallationName Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the node
        /// </summary>
        public SiteName SiteName { get; set; }
    }
}