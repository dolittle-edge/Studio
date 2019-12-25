// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Infrastructure.Domain
{
    /// <summary>
    /// Represents the map between a <see cref="Guid"/> and a natural key value of any type.
    /// </summary>
    /// <typeparam name="TKey">Type of key.</typeparam>
    public class NaturalKeyMap<TKey>
    {
        /// <summary>
        /// Gets or sets the <see cref="Guid"/> for the key.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the actual natural key value.
        /// </summary>
        public TKey Key { get; set; }
    }
}