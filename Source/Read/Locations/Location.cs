/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Dolittle.ReadModels;

namespace Read.Locations
{
    public class Location : IReadModel
    {
        public LocationId Id {get; set;}
        
        public LocationName Name {get; set;}
    }
}
