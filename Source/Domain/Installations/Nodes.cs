/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Concepts.Installations;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Installations;

namespace Domain.Installations
{
    public class Nodes : AggregateRoot
    {
        class Node
        {
            public Node(NodeId nodeId) => NodeId = nodeId;
            public NodeId NodeId { get; }
            public string Name { get; set; }
        }

        readonly List<Node> _nodes = new List<Node>();

        public Nodes(EventSourceId id) : base(id) {}

        public void Register(NodeId nodeId, string name)
        {
            ThrowIfNodeNameIsAlreadyUsed(name);

            Apply(new NodeRegistered(nodeId, name));
        }

        public void RegisterToInstallation(NodeId nodeId, string name, InstallationId installationId)
        {
            ThrowIfNodeNameIsAlreadyUsed(name);

            Apply(new NodeRegisteredToInstallation(nodeId, name, installationId));
        }

        public void Rename(string oldName, string newName)
        {
            ThrowIfNodeNameIsAlreadyUsed(newName);

            var node = _nodes.Single(_ => _.Name == oldName);
            Apply(new NodeRenamed(node.NodeId, newName));
        }

        void On(NodeRegistered @event)
        {
            _nodes.Add(new Node(@event.NodeId) { Name = @event.Name });
        }

        void On(NodeRenamed @event)
        {
            _nodes.Single(_ => _.NodeId == @event.NodeId).Name = @event.Name;
        }

        void ThrowIfNodeNameIsAlreadyUsed(string name)
        {
            if (_nodes.Any(_ => _.Name == name)) throw new NodeNameAlreadyUsed(name);
        }
    }
}