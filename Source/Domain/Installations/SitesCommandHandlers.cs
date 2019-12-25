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
    public class SitesCommandHandlers : ICanHandleCommands
    {
        readonly IExecutionContextManager _executionContextManager;
        readonly IAggregateOf<Sites> _sites;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;

        public SitesCommandHandlers(
            IAggregateOf<Sites> sites,
            INaturalKeysOf<SiteName> siteNameKeys,
            IExecutionContextManager executionContextManager)
        {
            _executionContextManager = executionContextManager;
            _sites = sites;
            _siteNameKeys = siteNameKeys;
        }

        public void Handle(RegisterSite register)
        {
            var siteId = Guid.NewGuid();
            if (_sites
                .Rehydrate(_executionContextManager.Current.Tenant.Value)
                .Perform(_ => _.Register(siteId, register.Name)))
            {
                _siteNameKeys.Associate(register.Name, siteId);
            }
        }

        public void Handle(RenameSite rename)
        {
            var siteId = _siteNameKeys.GetFor(rename.OldName);
            if (_sites
                .Rehydrate(_executionContextManager.Current.Tenant.Value)
                .Perform(_ => _.Rename(rename.OldName, rename.NewName)))
            {
                _siteNameKeys.Associate(rename.NewName, siteId);
            }
        }
    }
}