/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Concepts.Installations;
using Dolittle.Domain;
using Dolittle.Rules;
using Dolittle.Runtime.Events;
using Events.Installations;

namespace Domain.Installations
{
    public class InstallationsOnSite : AggregateRoot
    {
        static Reason InstallationNameAlreadyExists = Reason.Create("2144abf5-fec4-458f-866a-fdab84515d9a","Installation '{Name}' already exists");
        static Reason InstallationWithNameDoesNotExists = Reason.Create("a9c05481-ea6c-4ca3-a53e-a2bc378c6f34","Installation '{Name}' does not exist");

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
            if( Evaluate(() => DuplicateInstallationNameNotAllowed(name)) )
                Apply(new InstallationStarted(installationId, name));
        }

        public void Rename(string oldName, string newName, InstallationId installationId)
        {
            if( !Evaluate(
                    () => InstallationMustExist(oldName),
                    () => DuplicateInstallationNameNotAllowed(newName)) ) return;

            var installation = _installations.Single(_ => _.InstallationId == installationId);
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

        RuleEvaluationResult InstallationMustExist(string name)
        {
            if (!_installations.Any(_ => _.Name == name)) return RuleEvaluationResult.Fail(name, InstallationWithNameDoesNotExists.WithArgs(new{Name=name}));
            return RuleEvaluationResult.Success;
        }

        RuleEvaluationResult DuplicateInstallationNameNotAllowed(string name)
        {
            if (_installations.Any(_ => _.Name == name)) return RuleEvaluationResult.Fail(name, InstallationNameAlreadyExists.WithArgs(new{Name=name}));
            return RuleEvaluationResult.Success;
        }
    }
}