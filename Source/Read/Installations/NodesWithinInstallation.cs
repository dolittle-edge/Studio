// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Concepts.Installations;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Infrastructure.Domain;

namespace Read.Installations
{
    /// <summary>
    /// Represents a query for getting all locactions.
    /// </summary>
    public class NodesWithinInstallation : IQueryFor<AssociatedNode>
    {
        readonly IReadModelRepositoryFor<AssociatedNode> _nodes;
        readonly INaturalKeysOf<InstallationOnSite> _installationOnSiteKeys;
        readonly INaturalKeysOf<SiteName> _siteNameKeys;

        public NodesWithinInstallation(
            IReadModelRepositoryFor<AssociatedNode> nodes,
            INaturalKeysOf<SiteName> siteNameKeys,
            INaturalKeysOf<InstallationOnSite> installationOnSiteKeys)
        {
            _nodes = nodes;
            _installationOnSiteKeys = installationOnSiteKeys;
            _siteNameKeys = siteNameKeys;
        }

        public InstallationName InstallationName { get; set; }

        public SiteName SiteName { get; set; }

        public IQueryable<AssociatedNode> Query => _nodes.Query.Where(_ => _.InstallationId == InstallationId);

        InstallationId InstallationId
        {
            get
            {
                var siteId = _siteNameKeys.GetFor(SiteName);
                return _installationOnSiteKeys.GetFor(new InstallationOnSite { SiteId = siteId, InstallationName = InstallationName });
            }
        }
    }
}