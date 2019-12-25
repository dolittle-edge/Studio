// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Concepts;

namespace Concepts.Installations
{
    /// <summary>
    /// Represents the concept of the name of a node.
    /// </summary>
    public class SiteName : ConceptAs<string>
    {
        public static implicit operator SiteName(string value) => new SiteName { Value = value };
    }
}