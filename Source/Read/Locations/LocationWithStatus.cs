/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts.Locations;
using Dolittle.ReadModels;

namespace Read.Locations
{
    /// <summary>
    /// Represents a location
    /// </summary>
    public class LocationWithStatus : IReadModel
    {   
        /// <summary>
        /// Gets or sets the unique identifier for a location
        /// </summary>
        public LocationId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the location
        /// </summary>
        public LocationName Name { get; set; }

        /// <summary>
        /// Gets or sets the number of connected nodes
        /// </summary>
        public int ConnectedNodes { get; set; }

        /// <summary>
        /// Gets or sets the total number of nodes expected to be connected
        /// </summary>
        public int TotalNodes { get; set;}

        /// <summary>
        /// Gets or sets the <see cref="DateTimeOffset"/> representing the last time the location was seen
        /// </summary>
        public DateTimeOffset LastSeen { get; set; }
    }    
}