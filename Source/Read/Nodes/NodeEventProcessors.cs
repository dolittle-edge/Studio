/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Dolittle.IO.Tenants;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Nodes;

namespace Read.Nodes {
    public class NodeEventProcessors : ICanProcessEvents {
        readonly INodeManager _nodeManager;

        public NodeEventProcessors (INodeManager nodeManager) {
            _nodeManager = nodeManager;
        }

        [EventProcessor ("191e2a46-3769-ec50-a2b7-e4bd027ab15f")]
        public void Process (NodeAdded @event, EventSourceId id) {

            _nodeManager.Add(new Node {
                Id = id.Value,
                Name = @event.Name
            });
        }
    }
}