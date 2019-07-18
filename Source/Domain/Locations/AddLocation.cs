/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Dolittle.Commands;

namespace Domain.Locations
{
    public class AddLocation : ICommand
    {
        public LocationId Id {get; set;}
        public LocationName Name {get; set;}
    }
}
