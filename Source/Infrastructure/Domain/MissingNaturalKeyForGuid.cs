// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Infrastructure.Domain
{
    /// <summary>
    /// The exception that gets thrown when a natural key is missing for a <see cref="Guid"/>.
    /// </summary>
    public class MissingNaturalKeyForGuid : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingNaturalKeyForGuid"/> class.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> there is a missing natural key for.</param>
        public MissingNaturalKeyForGuid(Guid id)
            : base($"Natural key for Guid '{id}' does not exist")
        {
        }
    }
}