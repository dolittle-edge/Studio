/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Nodes
{
    public class AllNodes : IQueryFor<Node>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;

        public AllNodes(IReadModelRepositoryFor<Node> nodes) => _nodes = nodes;

        public IQueryable<Node> Query => _nodes.Query;
    }
}