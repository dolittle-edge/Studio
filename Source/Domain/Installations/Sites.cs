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
    public class Sites : AggregateRoot
    {
        class Site
        {
            public Site(SiteId siteId) => SiteId = siteId;
            public SiteId SiteId { get; }
            public string Name { get; set; }
        }

        readonly List<Site> _sites = new List<Site>();

        public Sites(EventSourceId id) : base(id) {}

        public void Register(SiteId siteId, string name)
        {
            ThrowIfSiteNameIsAlreadyUsed(name);

            Apply(new SiteRegistered(siteId, name));
        }

        public void Rename(string oldName, string newName)
        {
            ThrowIfSiteNameIsAlreadyUsed(newName);

            var site = _sites.Single(_ => _.Name == oldName);
            Apply(new SiteRenamed(site.SiteId, newName));
        }

        void On(SiteRegistered @event)
        {
            _sites.Add(new Site(@event.SiteId) { Name = @event.Name });
        }

        void On(SiteRenamed @event)
        {
            _sites.Single(_ => _.SiteId == @event.SiteId).Name = @event.Name;
        }

        void ThrowIfSiteNameIsAlreadyUsed(string name)
        {
            if (_sites.Any(_ => _.Name == name)) throw new SiteNameAlreadyUsed(name);
        }
    }
}