/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Concepts.Installations;
using Dolittle.Domain;
using Dolittle.Rules;
using Dolittle.Runtime.Events;
using Events.Installations;

namespace Domain.Installations
{
    public class Nodes : AggregateRoot
    {
        static Reason NodeNameAlreadyExists = Reason.Create("aa184789-1c5d-44cd-9890-a292e3993748", "Node '{Node}' already exists");
        static Reason NodeWithNameDoesNotExists = Reason.Create("215b195e-e88a-4457-a7c8-18c3f49e06d1", "Node '{Node}' does not exist");

        class Installation
        {
            public Installation(InstallationId installationId) => InstallationId = installationId;
            public InstallationId InstallationId { get; }
        }

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
            if (Evaluate(() => DuplicateNodeNameNotAllowed(name)))
            Apply(new NodeRegistered(nodeId, name));
        }

        public void Register(NodeId nodeId, string name, InstallationId installationId)
        {
            if (Evaluate(() => DuplicateNodeNameNotAllowed(name)))
            Apply(new NodeRegisteredWithInstallation(nodeId, name, installationId));
        }

        public void Rename(string oldName, string newName)
        {
            if (Evaluate(
                    () => NodeMustExist(oldName),
                    () => DuplicateNodeNameNotAllowed(newName)))
            {
                var node = _nodes.Single(_ => _.Name == oldName);
                Apply(new NodeRenamed(node.NodeId, newName));
            }
        }

        void On(NodeRegistered @event)
        {
            _nodes.Add(new Node(@event.NodeId) { Name = @event.Name });
        }

        void On(NodeRenamed @event)
        {
            _nodes.Single(_ => _.NodeId == @event.NodeId).Name = @event.Name;
        }

        RuleEvaluationResult NodeMustExist(string name)
        {
            if (!_nodes.Any(_ => _.Name == name)) return RuleEvaluationResult.Fail(name, NodeWithNameDoesNotExists.WithArgs(new{Site=name}));
            return RuleEvaluationResult.Success;
        }


        RuleEvaluationResult DuplicateNodeNameNotAllowed(string name)
        {
            if (_nodes.Any(_ => _.Name == name)) return RuleEvaluationResult.Fail(name, NodeNameAlreadyExists.WithArgs(new{Site=name}));
            return RuleEvaluationResult.Success;
        }
    }
}