/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installation
{
    /// <summary>
    /// Represents a node at a location
    /// </summary>
    public class Site : IReadModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for a node
        /// </summary>
        public SiteId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the node
        /// </summary>
        public SiteName Name { get; set; }
    }
}