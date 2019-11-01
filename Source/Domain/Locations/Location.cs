/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Locations;

namespace Domain.Locations
{
    public class Location : AggregateRoot
    {
        public Location(EventSourceId eventSourceId) : base(eventSourceId)
        {
            
        }
        public void Create(string name)
        {
            Apply(new LocationCreated(name));            
        }
    }
}