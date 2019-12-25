// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class AllSites : IQueryFor<Site>
    {
        readonly IReadModelRepositoryFor<Site> _sites;

        public AllSites(IReadModelRepositoryFor<Site> sites)
        {
            _sites = sites;
        }

        public IQueryable<Site> Query => _sites.Query;
    }
}