/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Nodes;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Nodes;

namespace Domain.Nodes
{
    public class Node : AggregateRoot
    {
        public Node(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void Add(NodeName name)
        {
            Apply(new NodeAdded(name));
        }
    }
}