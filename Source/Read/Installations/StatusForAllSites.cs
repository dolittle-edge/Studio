// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.Installations
{
    public class StatusForAllSites : IQueryFor<SiteStatus>
    {
        readonly IMongoCollection<SiteStatus> _siteStatus;

        public StatusForAllSites(IMongoCollection<SiteStatus> siteStatus)
        {
            _siteStatus = siteStatus;
        }

        public IQueryable<SiteStatus> Query => _siteStatus.AsQueryable();
    }
}