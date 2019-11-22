/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.Installations;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Infrastructure.Domain;

namespace Read.Installations
{
    /// <summary>
    /// Represents a query for getting all locactions
    /// </summary>
    public class InstallationsOnSite : IQueryFor<Installation>
    {
        readonly IReadModelRepositoryFor<Installation> _installations;
        private readonly INaturalKeysOf<SiteName> _siteNameKeys;

        public InstallationsOnSite(
            IReadModelRepositoryFor<Installation> installations,
            INaturalKeysOf<SiteName> siteNameKeys)
        {
            _installations = installations;
            _siteNameKeys = siteNameKeys;
        }

        public SiteName SiteName { get; set; }

        // public IQueryable<Installation> Query => _installations.Query;
        public IQueryable<Installation> Query
        {
            get
            {
                var siteId = _siteNameKeys.GetFor(SiteName);
                return _installations.Query.Where(_ => _.SiteId == siteId).AsQueryable();
            }
        }
    }
}