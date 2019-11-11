/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;


namespace Events.Locations.Nodes
{
    public class NodeAdded : IEvent
    {
        public NodeAdded(string name, Guid locationId)
        {
            Name = name;
            LocationId = locationId;
        }

        public string Name { get; }
        public Guid LocationId { get; }
    }
}