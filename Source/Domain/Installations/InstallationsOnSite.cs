/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Concepts.Installations;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Installations;

namespace Domain.Installations
{
    public class InstallationsOnSite : AggregateRoot
    {
        class Installation
        {
            public Installation(InstallationId installationId) => InstallationId = installationId;
            public InstallationId InstallationId { get; }
            public string Name { get; set; }
            public SiteId SiteId { get; set; }
        }

        readonly List<Installation> _installations = new List<Installation>();

        public InstallationsOnSite(EventSourceId id) : base(id) { }

        public void Start(InstallationId installationId, string name)
        {
            ThrowIfInstallationNameIsAlreadyUsed(name);

            Apply(new InstallationStarted(installationId, name));
        }

        public void Rename(string oldName, string newName)
        {
            ThrowIfInstallationNameIsAlreadyUsed(newName);

            var installation = _installations.Single(_ => _.Name == oldName);
            Apply(new InstallationRenamed(installation.InstallationId, newName));
        }

        void On(InstallationStarted @event)
        {
            _installations.Add(new Installation(@event.InstallationId) { Name = @event.Name });
        }

        void On(InstallationRenamed @event)
        {
            _installations.Single(_ => _.InstallationId == @event.InstallationId).Name = @event.Name;
        }

        void ThrowIfInstallationNameIsAlreadyUsed(string name)
        {
            if (_installations.Any(_ => _.Name == name)) throw new InstallationNameAlreadyUsed(name);
        }
    }
}