/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events;

namespace Events.Locations.Nodes
{
    public class NodeAdded : IEvent
    {
        public NodeAdded(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}