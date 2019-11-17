/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Infrastructure.Domain
{
    /// <summary>
    /// The exception that gets thrown when a natural key is missing for a <see cref="Guid"/>
    /// </summary>
    public class MissingNaturalKeyForGuid : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MissingKeyForGuid"/>
        /// </summary>
        /// <param name="guid"><see cref="Guid"/> there is a missing natural key for</param>
        public MissingNaturalKeyForGuid(Guid guid) : base($"Natural key for Guid '{guid}' does not exist") {}
    }
}