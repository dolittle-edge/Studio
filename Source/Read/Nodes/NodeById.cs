/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts.Nodes;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Nodes
{
    public class NodeById : IQueryFor<Node>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;

        public NodeById(IReadModelRepositoryFor<Node> nodes)
        {
            _nodes = nodes;
        }

        public NodeId Id { get; set; }

        public IQueryable<Node> Query => _nodes.Query.Where(_ => _.Id == Id);
    }
}