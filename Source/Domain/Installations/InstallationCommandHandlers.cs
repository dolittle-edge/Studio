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
    public class InstallationCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Installations> _repository;
        readonly IExecutionContextManager _executionContextManager;

        public InstallationCommandHandlers(
            IAggregateRootRepositoryFor<Installations> repository,
            IExecutionContextManager executionContextManager)
        {
            _repository = repository;
            _executionContextManager = executionContextManager;
        }

        public void Handle(CreateInstallation register)
        {
            var installations = _repository.Get(_executionContextManager.Current.Tenant.Value);
            installations.Create(Guid.NewGuid(), register.Name, register.SiteName);
        }

        // public void Handle(RenameSite rename)
        // {
        //     var sites = _repository.Get(_executionContextManager.Current.Tenant.Value);
        //     sites.Rename(rename.OldName, rename.NewName);
        // }
    }
}