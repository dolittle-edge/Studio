/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Installations
{
    /// <summary>
    /// Represents the concept of the name of a node
    /// </summary>
    public class NodeName : ConceptAs<string>
    {
        public static implicit operator NodeName(string value) => new NodeName { Value = value };
    }
}