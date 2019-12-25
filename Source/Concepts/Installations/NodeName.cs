// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Concepts;

namespace Concepts.Installations
{
    /// <summary>
    /// Represents the concept of the name of a node.
    /// </summary>
    public class NodeName : ConceptAs<string>
    {
        public static implicit operator NodeName(string value) => new NodeName { Value = value };
    }
}