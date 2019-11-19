/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Installations
{
    public class InstallationName : ConceptAs<string>
    {
        public static implicit operator InstallationName(string value) => new InstallationName { Value = value };
    }
}