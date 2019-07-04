/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Locations;

namespace Domain.Locations
{
    public class Location : AggregateRoot
    {
        public Location(EventSourceId id) : base(id) {}

        public void Add(LocationName name)
        {
            Apply(new LocationAdded(name));
        }
    }
}
