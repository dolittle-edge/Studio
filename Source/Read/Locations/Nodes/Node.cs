/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations.Nodes;
using Dolittle.ReadModels;

namespace Read.Locations.Nodes
{
    /// <summary>
    /// Represents a node at a location
    /// </summary>
    public class Node : IReadModel
    {   
        /// <summary>
        /// Gets or sets the unique identifier for a node
        /// </summary>
        public NodeId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the node
        /// </summary>
        public NodeName Name { get; set; }
    }
}