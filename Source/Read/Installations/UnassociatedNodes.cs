// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Installations
{
    /// <summary>
    /// Represents a query for getting all locactions.
    /// </summary>
    public class UnassociatedNodes : IQueryFor<UnassociatedNode>
    {
        readonly IReadModelRepositoryFor<UnassociatedNode> _nodes;

        public UnassociatedNodes(IReadModelRepositoryFor<UnassociatedNode> nodes)
        {
            _nodes = nodes;
        }

        public IQueryable<UnassociatedNode> Query => _nodes.Query;
    }
}