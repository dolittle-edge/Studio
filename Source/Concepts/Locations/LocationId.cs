/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Concepts.Locations
{
    /// <summary>
    /// Represents the unique identifier of a location
    /// </summary>
    public class LocationId : ConceptAs<Guid>
    {
        /// <summary>
        /// Implicitly convert from a <see cref="Guid"/> to a <see cref="LocationId"/>
        /// </summary>
        /// <param name="value"><see cref="Guid"/> to convert from</param>
        public static implicit operator LocationId(Guid value)
        {
            return new LocationId { Value = value };
        }
    }
}