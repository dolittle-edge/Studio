/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts.Locations;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Read.Locations.Nodes;

namespace Read.Locations
{
    /// <summary>
    /// Represents a query for getting all nodes in a location
    /// </summary>
    public class NodesByLocation : IQueryFor<Node>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public NodesByLocation(IReadModelRepositoryFor<Node> nodes)
        {
            _nodes = nodes;
        }
        /// <summary>
        /// 
        /// </summary>
        public LocationId LocationId { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Node> Query => _nodes.Query.Where(_=>_.LocationId == LocationId).AsQueryable();
    }
}