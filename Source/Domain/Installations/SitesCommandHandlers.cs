/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Execution;

namespace Domain.Installations
{
    public class SitesCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Sites> _repository;
        readonly IExecutionContextManager _executionContextManager;

        public SitesCommandHandlers(
            IAggregateRootRepositoryFor<Sites> repository,
            IExecutionContextManager executionContextManager)
        {
            _repository = repository;
            _executionContextManager = executionContextManager;
        }

        public void Handle(RegisterSite register)
        {
            var sites = _repository.Get(_executionContextManager.Current.Tenant.Value);
            sites.Register(Guid.NewGuid(), register.Name);
        }

        public void Handle(RenameSite rename)
        {
            var sites = _repository.Get(_executionContextManager.Current.Tenant.Value);
            sites.Rename(rename.OldName, rename.NewName);
        }
    }
}