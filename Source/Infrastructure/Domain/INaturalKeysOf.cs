// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Infrastructure.Domain
{
    /// <summary>
    /// Defines a system that is capable of mapping natural keys back and forth to <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TKey">Type of key.</typeparam>
    /// <remarks>
    /// This system requires the natural key to be a <see cref="ConceptAs{T}"/> there will be a unique map per
    /// type.
    /// </remarks>
    public interface INaturalKeysOf<TKey>
    {
        /// <summary>
        /// Associate a natural key with a <see cref="Guid"/>.
        /// </summary>
        /// <param name="key">Key to associate.</param>
        /// <param name="id"><see cref="Guid"/> it is associated with.</param>
        void Associate(TKey key, Guid id);

        /// <summary>
        /// Get the <see cref="EventSourceId"/> for a natural key.
        /// </summary>
        /// <param name="key">The natural key.</param>
        /// <returns>The <see cref="Guid"/>.</returns>
        Guid GetFor(TKey key);

        /// <summary>
        /// Get the natural key for a <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> for the association.</param>
        /// <returns>The natural key.</returns>
        TKey GetFor(Guid id);
    }
}