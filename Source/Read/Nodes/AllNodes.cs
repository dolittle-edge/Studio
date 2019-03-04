/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.Nodes
{
    public class AllNodes : IQueryFor<Node>
    {
        public AllNodes(INodes nodes)
        {
            Query = nodes.GetAllNodesFor(Guid.Parse("1c8aa985-5350-4b69-aa43-e6c761b97d01")).AsQueryable();
        }

        public IQueryable<Node> Query { get; }
    }
}