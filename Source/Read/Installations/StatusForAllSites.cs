/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
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