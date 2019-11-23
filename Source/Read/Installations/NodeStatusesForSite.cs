/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts.Installations;
using Dolittle.Queries;
using Infrastructure.Domain;
using MongoDB.Driver;

namespace Read.Installations
{
    public class NodeStatusesForSite : IQueryFor<NodeStatus>
    {
        readonly IMongoCollection<NodeStatus> _nodeStatusCollection;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;

        public NodeStatusesForSite(
            IMongoCollection<NodeStatus> nodeStatusCollection,
            INaturalKeysOf<SiteName> siteNameKeys)
        {
            _nodeStatusCollection = nodeStatusCollection;
            _siteNameKeys = siteNameKeys;
        }

        public SiteName SiteName { get; set; }

        SiteId SiteId => _siteNameKeys.GetFor(SiteName);

        public IQueryable<NodeStatus> Query => _nodeStatusCollection.Find(_ => _.SiteId == SiteId).ToList().AsQueryable();
    }
}