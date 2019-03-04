/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Locations;

namespace Read.Nodes
{
    public interface INodes
    {
        IEnumerable<Node> GetAllNodesFor(LocationId locationId);
        void Add(LocationId locationId, Node node);
    }
}
