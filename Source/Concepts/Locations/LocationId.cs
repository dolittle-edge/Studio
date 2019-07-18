/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts.Locations
{
    /// <summary>
    /// Represents the unique identifier of a location
    /// </summary>
    public class LocationId : ConceptAs<Guid>
    {
        public static readonly LocationId NotSet = Guid.Empty;
        public static implicit operator LocationId(Guid value)
        {
            return new LocationId { Value = value };
        }

        public static implicit operator EventSourceId(LocationId id)
        {
            return new EventSourceId { Value = id.Value };
        }
    }
}