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
    public class InstallationsCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateOf<InstallationsOnSite> _installationsOnSite;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;
        readonly INaturalKeysOf<InstallationOnSite> _installationOnSiteKeys;

        public InstallationsCommandHandlers(
            IAggregateOf<InstallationsOnSite> installationsOnSite,
            INaturalKeysOf<SiteName> siteNameKeys,
            INaturalKeysOf<InstallationOnSite> installationOnSiteKeys)
        {
            _installationsOnSite = installationsOnSite;
            _siteNameKeys = siteNameKeys;
            _installationOnSiteKeys = installationOnSiteKeys;
        }

        public void Handle(CreateInstallation command)
        {
            var siteId = _siteNameKeys.GetFor(command.SiteName);
            var installationId = Guid.NewGuid();

            if (_installationsOnSite
                .Rehydrate(siteId)
                .Perform(_ => _.Start(installationId, command.Name)))
            {
                _installationOnSiteKeys.Associate(new InstallationOnSite { SiteId = siteId, InstallationName = command.Name }, installationId);
            }
        }

        public void Handle(RenameInstallation command)
        {
            var installationId = _installationOnSiteKeys.GetFor(new InstallationOnSite { SiteId = command.SiteId, InstallationName = command.OldName });

            if (_installationsOnSite
                .Rehydrate(command.SiteId)
                .Perform(_ => _.Rename(command.OldName, command.NewName)))
            {
                _installationOnSiteKeys.Associate(new InstallationOnSite { SiteId = command.SiteId, InstallationName = command.NewName }, installationId);
            }
        }
    }
}