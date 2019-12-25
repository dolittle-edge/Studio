// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Installations;

namespace Read.Installations
{
    public class NodeEventProcessors : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<AssociatedNode> _associatedNodes;
        readonly IReadModelRepositoryFor<UnassociatedNode> _unassociatedNodes;

        public NodeEventProcessors(
            IReadModelRepositoryFor<AssociatedNode> associatedNodes,
            IReadModelRepositoryFor<UnassociatedNode> unassociatedNodes)
        {
            _associatedNodes = associatedNodes;
            _unassociatedNodes = unassociatedNodes;
        }

        [EventProcessor("c73b4930-e2fd-411c-94b8-f394789b9abc")]
        public void Process(NodeRegistered @event)
        {
            _unassociatedNodes.Insert(new UnassociatedNode { Id = @event.NodeId, Name = @event.Name });
        }

        [EventProcessor("aa8f67f8-640a-4d6f-915e-7ed0d18a5a8d")]
        public void Process(NodeRegisteredWithInstallation @event)
        {
            _associatedNodes.Insert(new AssociatedNode
            {
                Id = @event.NodeId,
                Name = @event.Name,
                InstallationId = @event.InstallationId
            });
        }

        [EventProcessor("d8c62032-00be-439c-bd9c-aed304c6a234")]
        public void Process(NodeRenamed @event)
        {
            var node = _unassociatedNodes.GetById(@event.NodeId);
            node.Name = @event.Name;
            _unassociatedNodes.Update(node);
        }
    }
}