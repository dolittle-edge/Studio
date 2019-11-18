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
    public class Sites : AggregateRoot
    {
        public static BrokenRuleReason SiteNameAlreadyExists = BrokenRuleReason.Create("9ceff948-f9e0-4584-9478-94a00c45b55c", "Site '{Site}' already exists");
        public static BrokenRuleReason SiteWithNameDoesNotExists = BrokenRuleReason.Create("60c1f7be-3937-4625-a23a-1842e411ac55", "Site '{Site}' does not exist");

        public class Site
        {
            public Site(SiteId siteId) => SiteId = siteId;
            public SiteId SiteId { get; }
            public string Name { get; set; }
        }

        readonly List<Site> _sites = new List<Site>();

        public Sites(EventSourceId id) : base(id) { }

        public void Register(SiteId siteId, string name)
        {
            if (Evaluate(() => DuplicateSiteNameNotAllowed(name)))
                Apply(new SiteRegistered(siteId, name));
        }

        public void Rename(string oldName, string newName)
        {
            if (Evaluate(
                    () => SiteMustExist(oldName),
                    () => DuplicateSiteNameNotAllowed(newName)))
            {
                var site = _sites.Single(_ => _.Name == oldName);
                Apply(new SiteRegistered(site.SiteId, newName));
            }
        }

        void On(SiteRegistered @event)
        {
            _sites.Add(new Site(@event.SiteId) { Name = @event.Name });
        }

        void On(SiteRenamed @event)
        {
            _sites.Single(_ => _.SiteId == @event.SiteId).Name = @event.Name;
        }

        RuleEvaluationResult SiteMustExist(string name)
        {
            if (!_sites.Any(_ => _.Name == name)) return RuleEvaluationResult.Fail(name, SiteWithNameDoesNotExists.WithArgs(new{Site=name}));
            return RuleEvaluationResult.Success;
        }

        RuleEvaluationResult DuplicateSiteNameNotAllowed(string name)
        {
            if (_sites.Any(_ => _.Name == name)) return RuleEvaluationResult.Fail(name, SiteNameAlreadyExists.WithArgs(new{Site=name}));
            return RuleEvaluationResult.Success;
        }
    }
}