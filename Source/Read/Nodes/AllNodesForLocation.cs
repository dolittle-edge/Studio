/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Concepts.Locations;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Nodes
{
    public class AllNodesForLocation : IQueryFor<Node>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;

        public AllNodesForLocation(IReadModelRepositoryFor<Node> nodes)
        {
            _nodes = nodes;
        }

        public LocationId Location { get; set; }

        public IQueryable<Node> Query => _nodes.Query.Where(_ => _.LocationId == Location);
    }
}