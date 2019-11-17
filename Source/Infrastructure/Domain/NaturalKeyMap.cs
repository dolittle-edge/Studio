/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Infrastructure.Domain
{
    /// <summary>
    /// Represents the map between a <see cref="Guid"/> and a natural key value of any type
    /// </summary>
    public class NaturalKeyMap<T>
    {
        /// <summary>
        /// Gets or sets the <see cref="Guid"/> for the key
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the actual natural key value
        /// </summary>
        public T Key { get; set; }
    }
}