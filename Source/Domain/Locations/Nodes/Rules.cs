/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations.Nodes;

namespace Domain.Locations.Nodes
{
    public delegate bool NameMustBeUnique(NodeName name);
    public delegate bool NotExist(NodeId id);
}