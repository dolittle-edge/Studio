/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Concepts.Locations;
using Dolittle.Queries;

namespace Read.Nodes
{
    public class AllNodesForLocation : IQueryFor<Node>
    {
        readonly INodes _nodes;

        public AllNodesForLocation(INodes nodes)
        {
            _nodes = nodes;
        }

        public LocationId Location { get; set; }

        public IQueryable<Node> Query => _nodes.GetAllNodesFor(Location).AsQueryable();
    }
}