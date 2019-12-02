/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts.Installations;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
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
                _installationOnSiteKeys.Associate(
                    new InstallationOnSite { SiteId = siteId, InstallationName = command.Name },
                    installationId
                );
            }
        }

        public void Handle(RenameInstallation command)
        {
            var siteId = _siteNameKeys.GetFor(command.SiteName);
            var installationId = _installationOnSiteKeys.GetFor(
                new InstallationOnSite { SiteId = siteId, InstallationName = command.OldName }
            );

            if (_installationsOnSite
                .Rehydrate(siteId)
                // we already know the unique installationId here so we can pass that into the Aggregate instead of having
                // to make another lookup for the installation with a siteID
                .Perform(_ => _.Rename(command.OldName, command.NewName, installationId)))
            {
                _installationOnSiteKeys.Associate(
                    new InstallationOnSite { SiteId = siteId, InstallationName = command.NewName },
                    installationId
                );
            }
        }
    }
}