/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Dolittle.ReadModels;

namespace Read.Locations
{
    /// <summary>
    /// Represents a location
    /// </summary>
    public class Location : IReadModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for a location
        /// </summary>
        public LocationId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the location
        /// </summary>
        public LocationName Name { get; set; }
    }
}