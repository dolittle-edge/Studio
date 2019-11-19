/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Installations
{
    /// <summary>
    /// Represents the concept of the name of a location
    /// </summary>
    public class SiteName : ConceptAs<string>
    {
        public static implicit operator SiteName(string value) => new SiteName { Value = value };
    }
}