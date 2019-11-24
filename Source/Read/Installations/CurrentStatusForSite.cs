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
    public class CurrentStatusForSite : IQueryFor<SiteStatus>
    {
        readonly IReadModelRepositoryFor<SiteStatus> _repository;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;

        public CurrentStatusForSite(
            IReadModelRepositoryFor<SiteStatus> repository,
            INaturalKeysOf<SiteName> siteNameKeys)
        {
            _repository = repository;
            _siteNameKeys = siteNameKeys;
        }

        public SiteName SiteName { get; set; }

        public IQueryable<SiteStatus> Query => _repository.Query.Where(_ => _.Id == _siteNameKeys.GetFor(SiteName));
    }
}