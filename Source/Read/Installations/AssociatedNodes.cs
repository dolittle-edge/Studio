/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.Installations;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Installations
{
    /// <summary>
    /// Represents a query for getting all locactions
    /// </summary>
    public class NodesWithinInstallation : IQueryFor<AssociatedNode>
    {
        readonly IReadModelRepositoryFor<AssociatedNode> _nodes;

        public NodesWithinInstallation(IReadModelRepositoryFor<AssociatedNode> nodes)
        {
            _nodes = nodes;
        }

        public InstallationId InstallationId { get; set; }

        public IQueryable<AssociatedNode> Query => _nodes.Query.Where(_ => _.InstallationId == InstallationId);
    }
}