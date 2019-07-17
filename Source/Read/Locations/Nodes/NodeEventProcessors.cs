/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Locations.Nodes;

namespace Read.Locations.Nodes
{
    public class NodeEventProcessors : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Node> _nodes;

        public NodeEventProcessors(IReadModelRepositoryFor<Node> nodes)
        {
            this._nodes = nodes;
        }

        [EventProcessor("8c9f4260-52ac-48f2-a99a-1c3829e29b12")]
        public void Process(NodeAddedToLocation @event, EventSourceId id)
        {
            _nodes.Insert(new Node()
            {
                Id = id.Value,
                Name = @event.Name
            });
        }
    }
}