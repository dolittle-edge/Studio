/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Locations
{
    /// <summary>
    /// Represents the concept of the name of a location
    /// </summary>
    public class LocationName : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from <see cref="string"/> to <see cref="LocationName"/>
        /// </summary>
        /// <param name="value"><see cref="string"/> to convert from</param>
        public static implicit operator LocationName(string value)
        {
            return new LocationName {Value = value};
        }
    }
}