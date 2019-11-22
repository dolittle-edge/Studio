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

        InstallationId InstallationId
        {
            get
            {
                var siteId = _siteNameKeys.GetFor(SiteName);
                return _installationOnSiteKeys.GetFor(new InstallationOnSite { SiteId = siteId, InstallationName = InstallationName });
            }
        }

        public IQueryable<AssociatedNode> Query => _nodes.Query.Where(_ => _.InstallationId == InstallationId);
    }
}