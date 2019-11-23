/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.Installations;
using Dolittle.Logging;
using Infrastructure.Domain;
using MongoDB.Driver;

namespace Read.Installations
{
    public class CurrentNodeStatus : ICurrentNodeStatus
    {
        readonly IMongoCollection<NodeStatus> _nodeStatus;
        readonly IMongoCollection<SiteStatus> _siteStatus;
        readonly ILogger _logger;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;
        readonly INaturalKeysOf<InstallationOnSite> _installationOnSiteKeys;

        public CurrentNodeStatus(
            IMongoCollection<NodeStatus> nodeStatus,
            IMongoCollection<SiteStatus> siteStatus,
            INaturalKeysOf<SiteName> siteNameKeys,
            INaturalKeysOf<InstallationOnSite> installationOnSiteKeys,
            ILogger logger)
        {
            _nodeStatus = nodeStatus;
            _siteStatus = siteStatus;
            _logger = logger;
            _siteNameKeys = siteNameKeys;
            _installationOnSiteKeys = installationOnSiteKeys;
        }

        public void Report(
            SiteId siteId,
            InstallationId installationId,
            NodeId nodeId,
            IDictionary<string, float> metrics,
            IDictionary<string, string> infos)
        {
            var now = DateTimeOffset.UtcNow;
            var siteStatus = _siteStatus.Find(_ => _.Id == siteId).FirstOrDefault();
            if (siteStatus == null)
            {
                siteStatus = new SiteStatus
                {
                    Id = siteId,
                    LastSeenNodes = new Dictionary<string, DateTimeOffset>()
                };
            }

            siteStatus.LastSeenNodes[nodeId.ToString()] = now;
            _siteStatus.ReplaceOne(_ => _.Id == siteId, siteStatus, new UpdateOptions { IsUpsert = true });

            var nodeStatus = new NodeStatus
            {
                Id = nodeId,
                SiteId = siteId,
                SiteName = _siteNameKeys.GetFor(siteId),
                InstallationId = installationId,
                InstallationName = _installationOnSiteKeys.GetFor(installationId).InstallationName,
                Metrics = metrics,
                Infos = infos,
                LastSeen = now
            };
            _nodeStatus.ReplaceOne(_ => _.Id == nodeId, nodeStatus, new UpdateOptions { IsUpsert = true });
        }
    }
}