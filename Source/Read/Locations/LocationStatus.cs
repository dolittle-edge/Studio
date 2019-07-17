/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Locations;
using Dolittle.ReadModels;
using Read.Locations.Nodes;

namespace Read.Locations
{
    /// <summary>
    /// Represents the status of a location
    /// </summary>
    public class LocationStatus : IReadModel
    {
        public LocationId Id {get; set; }
        /// <summary>
        /// Gets or sets the name of the location
        /// </summary>
        public LocationName Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="NodeWithStatus">status for nodes</see>
        /// </summary>
        public IEnumerable<NodeWithStatus> Nodes { get; set; }
    }
}