/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Locations.Nodes
{
    /// <summary>
    /// Represents the concept of the name of a node
    /// </summary>
    public class NodeName : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from <see cref="string"/> to <see cref="NodeName"/>
        /// </summary>
        /// <param name="value"><see cref="string"/> to convert from</param>
        public static implicit operator NodeName(string value)
        {
            return new NodeName {Value = value};
        }
    }
}