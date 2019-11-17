/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Installations
{
    public class SiteName : ConceptAs<string>
    {
        public static implicit operator SiteName(string name) => new SiteName { Value = name };
    }
}