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
        readonly IAggregateOf<Nodes> _nodes;
        readonly IExecutionContextManager _executionContextManager;
        private readonly INaturalKeysOf<NodeName> _nodeNameKeys;
        private readonly INaturalKeysOf<InstallationName> _installationNameKeys;


        public NodesCommandHandler(
            IAggregateOf<Nodes> nodes,
            INaturalKeysOf<NodeName> nodeNameKeys,
            INaturalKeysOf<InstallationName> installationNameKeys,
            IExecutionContextManager executionContextManager)
        {
            _nodes = nodes;
            _nodeNameKeys = nodeNameKeys;
            _installationNameKeys = installationNameKeys;
            _executionContextManager = executionContextManager;
        }

        public void Handle(RegisterNode register)
        {
            var nodeId = Guid.NewGuid();
            if (_nodes
                .Rehydrate(_executionContextManager.Current.Tenant.Value)
                .Perform(_ => _.Register(nodeId, register.Name)))
            {
                _nodeNameKeys.Associate(register.Name, nodeId);
            }
        }

        public void Handle(RegisterNodeWithInstallation register)
        {
            var installationId = _installationNameKeys.GetFor(register.InstallationName);
            var nodeId = Guid.NewGuid();
            if (_nodes
                .Rehydrate(_executionContextManager.Current.Tenant.Value)
                .Perform(_ => _.Register(nodeId, register.Name, installationId)))
            {
                _nodeNameKeys.Associate(register.Name, nodeId);
            }
        }

        public void Handle(RenameNode rename)
        {
            /*
            var nodes = _nodes.Get(_executionContextManager.Current.Tenant.Value);
            nodes.Rename(rename.OldName, rename.NewName);
            var nodeId = _nodeNameKeys.GetFor(rename.OldName);
            _nodeNameKeys.Associate(rename.NewName, nodeId);*/
        }
    }
}