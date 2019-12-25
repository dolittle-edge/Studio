// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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

        readonly INaturalKeysOf<SiteName> _siteNameKeys;
        readonly INaturalKeysOf<NodeName> _nodeNameKeys;
        readonly INaturalKeysOf<InstallationOnSite> _installationOnSiteKeys;

        public NodesCommandHandler(
            IAggregateOf<Nodes> nodes,
            INaturalKeysOf<SiteName> siteNameKeys,
            INaturalKeysOf<NodeName> nodeNameKeys,
            INaturalKeysOf<InstallationOnSite> installationOnSiteKeys,
            IExecutionContextManager executionContextManager)
        {
            _nodes = nodes;
            _siteNameKeys = siteNameKeys;
            _nodeNameKeys = nodeNameKeys;
            _installationOnSiteKeys = installationOnSiteKeys;
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
            var siteId = _siteNameKeys.GetFor(register.SiteName);
            var installationId = _installationOnSiteKeys.GetFor(new InstallationOnSite { SiteId = siteId, InstallationName = register.InstallationName });
            var nodeId = Guid.NewGuid();
            if (_nodes
                .Rehydrate(_executionContextManager.Current.Tenant.Value)
                .Perform(_ => _.Register(nodeId, register.Name, siteId, installationId)))
            {
                _nodeNameKeys.Associate(register.Name, nodeId);
            }
        }

#if false
        public void Handle(RenameNode rename)
        {
            var nodes = _nodes.Get(_executionContextManager.Current.Tenant.Value);
            nodes.Rename(rename.OldName, rename.NewName);
            var nodeId = _nodeNameKeys.GetFor(rename.OldName);
            _nodeNameKeys.Associate(rename.NewName, nodeId);*/
        }
#endif
    }
}