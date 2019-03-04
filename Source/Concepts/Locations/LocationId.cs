/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Concepts.Locations
{
    public class LocationId : ConceptAs<Guid>
    {
        public static implicit operator LocationId(Guid value)
        {
            return new LocationId { Value = value };
        }
    }
}