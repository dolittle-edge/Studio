/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands;
using Dolittle.Domain;
using Concepts.Nodes;

namespace Domain.Nodes
{
    public class AddNode : ICommand
    {
        public NodeId Id { get; set; }
        public NodeName Name { get; set; }       
    }
}