/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Nodes
{
    public class NodeName : ConceptAs<string>
    {
        public static implicit operator NodeName(string value)
        {
            return new NodeName {Value = value};
        }
    }
}
