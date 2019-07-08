/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Nodes;

namespace Domain.Locations.Nodes
{
    public class LocatedNode : AggregateRoot
    {
        public LocatedNode(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void Add(NodeName name, LocationId locationId)
        {
            Apply(new NodeAddedToLocation(name, locationId));
        }
    }
}