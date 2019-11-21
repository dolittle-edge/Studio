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
    public class InstallationCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Installations> _repository;
        readonly IExecutionContextManager _executionContextManager;
        private readonly INaturalKeysOf<SiteName> _siteNameKeys;
        private readonly INaturalKeysOf<InstallationName> _installationNameKeys;

        public InstallationCommandHandlers(
            IAggregateRootRepositoryFor<Installations> repository,
            INaturalKeysOf<SiteName> siteNameKeys,
            INaturalKeysOf<InstallationName> installationNameKeys,
            IExecutionContextManager executionContextManager)
        {
            _repository = repository;
            _siteNameKeys = siteNameKeys;
            _installationNameKeys = installationNameKeys;
            _executionContextManager = executionContextManager;
        }

        public void Handle(CreateInstallation register)
        {
            var installations = _repository.Get(_executionContextManager.Current.Tenant.Value);
            var siteId = _siteNameKeys.GetFor(register.SiteName);
            var installationId = Guid.NewGuid();
            _installationNameKeys.Associate(register.Name, installationId);
            installations.Create(installationId, register.Name, siteId);
        }

        public void Handle(RenameInstallation rename)
        {
            var installations = _repository.Get(_executionContextManager.Current.Tenant.Value);
            installations.Rename(rename.OldName, rename.NewName);
            var installationId = _installationNameKeys.GetFor(rename.OldName);
            _installationNameKeys.Associate(rename.NewName, installationId);
        }
    }
}