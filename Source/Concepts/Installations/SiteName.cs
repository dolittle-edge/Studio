/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Installations
{
<<<<<<< HEAD
    /// <summary>
    /// Represents the concept of the name of a location
    /// </summary>
    public class SiteName : ConceptAs<string>
    {
        public static implicit operator SiteName(string value) => new SiteName { Value = value };
=======
    public class SiteName : ConceptAs<string>
    {
        public static implicit operator SiteName(string name) => new SiteName { Value = name };
>>>>>>> d6c837dd18cef3f2ae34858802c595701e5f4e5e
    }
}