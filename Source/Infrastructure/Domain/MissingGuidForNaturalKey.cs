/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Infrastructure.Domain
{
    /// <summary>
    /// The exception that gets thrown when a <see cref="Guid"/> is missing for a natural key
    /// </summary>
    public class MissingGuidForNaturalKey : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MissingKeyForGuid"/>
        /// </summary>
        /// <param name="key">Natural key there is a missing <see cref="Guid"/> for</param>
        public MissingGuidForNaturalKey(object key) : base($"Guid for Natural key '{key}' does not exist") {}
    }

}