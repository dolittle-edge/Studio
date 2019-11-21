/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts.Installations;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Execution;
using Infrastructure.Domain;

namespace Domain.Installations
{
    public class NodesCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Nodes> _repository;
        readonly IExecutionContextManager _executionContextManager;
        private readonly INaturalKeysOf<NodeName> _nodeNameKeys;

        public NodesCommandHandler(
            IAggregateRootRepositoryFor<Nodes> repository,
            INaturalKeysOf<NodeName> nodeNameKeys,
            IExecutionContextManager executionContextManager)
        {
            _repository = repository;
            _nodeNameKeys = nodeNameKeys;
            _executionContextManager = executionContextManager;
        }

        public void Handle(RegisterNode register)
        {
            var nodes = _repository.Get(_executionContextManager.Current.Tenant.Value);
            var nodeId = Guid.NewGuid();
            _nodeNameKeys.Associate(register.Name, nodeId);
            nodes.Register(nodeId, register.Name);
        }

        public void Handle(RenameNode rename)
        {
            var nodes = _repository.Get(_executionContextManager.Current.Tenant.Value);
            nodes.Rename(rename.OldName, rename.NewName);
            var nodeId = _nodeNameKeys.GetFor(rename.OldName);
            _nodeNameKeys.Associate(rename.NewName, nodeId);
        }
    }
}