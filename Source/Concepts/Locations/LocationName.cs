/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Locations
{
    public class LocationName : ConceptAs<string>
    {
        public static readonly LocationName NotSet = "";
        public static implicit operator LocationName(string value)
        {
            return new LocationName {Value = value};
        }
    }
}
