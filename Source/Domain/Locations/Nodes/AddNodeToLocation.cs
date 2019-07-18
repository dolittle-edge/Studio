/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands;
using Concepts.Locations.Nodes;
using Concepts.Locations;

namespace Domain.Locations.Nodes
{
    public class AddNodeToLocation : ICommand
    {
        public NodeId Id { get; set; }
        public LocationId LocationId { get; set; }
        public NodeName Name { get; set; }       
    }
}