/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Queries;

namespace Read.Nodes
{
    public class AllNodes : IQueryFor<Node>
    {
        public AllNodes(INodeManager nodes)
        {
            Query = nodes.GetAllNodes().AsQueryable();
        }

        public IQueryable<Node> Query { get; }
    }
}