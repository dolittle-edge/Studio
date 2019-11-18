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
    public class SitesCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Sites> _repository;
        readonly IExecutionContextManager _executionContextManager;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;

        public SitesCommandHandlers(
            IAggregateRootRepositoryFor<Sites> repository,
            INaturalKeysOf<SiteName> siteNameKeys,
            IExecutionContextManager executionContextManager)
        {
            _repository = repository;
            _siteNameKeys = siteNameKeys;
            _executionContextManager = executionContextManager;
        }

        public void Handle(RegisterSite register)
        {
            var sites = _repository.Get(_executionContextManager.Current.Tenant.Value);
            var siteId = Guid.NewGuid();
            _siteNameKeys.Associate(register.Name, siteId);
            sites.Register(siteId, register.Name);
        }

        public void Handle(RenameSite rename)
        {
            var sites = _repository.Get(_executionContextManager.Current.Tenant.Value);
            sites.Rename(rename.OldName, rename.NewName);
            var siteId = _siteNameKeys.GetFor(rename.OldName);
            _siteNameKeys.Associate(rename.NewName, siteId);
        }
    }
}