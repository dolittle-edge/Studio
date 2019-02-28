/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.ReadModels;
using Concepts.Nodes;
using Dolittle.Queries;

namespace Read.Nodes
{
    public class Node : IReadModel
    {
        public NodeId Id { get; set; }
        public NodeName Name { get; set; }
    }
}