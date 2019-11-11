/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Locations.Nodes
{
    /// <summary>
    /// Represents a query for getting all locactions
    /// </summary>
    public class AllNodes : IQueryFor<Node>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public AllNodes(IReadModelRepositoryFor<Node> nodes)
        {
            _nodes = nodes;
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Node> Query => _nodes.Query;
    }
}