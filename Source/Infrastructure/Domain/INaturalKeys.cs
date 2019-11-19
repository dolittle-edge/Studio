/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Infrastructure.Domain
{
    /// <summary>
    /// Defines a system that is capable of mapping natural keys back and forth to <see cref="Guid"/>
    /// </summary>
    /// <remarks>
    /// This system requires the natural key to be a <see cref="ConceptAs{T}"/> there will be a unique map per
    /// type.
    /// </remarks>
    public interface INaturalKeysOf<T>
    {
        /// <summary>
        /// Associate a natural key with a <see cref="Guid"/>
        /// </summary>
        /// <param name="key">Key to associate</param>
        /// <param name="guid"><see cref="Guid"/> it is associated with</param>
        void Associate(T key, Guid guid);

        /// <summary>
        /// Get the <see cref="EventSourceId"/> for a natural key
        /// </summary>
        /// <param name="key">The natural key</param>
        /// <returns>The <see cref="Guid"/></returns>
        Guid GetFor(T key);

        /// <summary>
        /// Get the natural key for a <see cref="Guid"/>
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/> for the association</param>
        /// <returns>The natural key</returns>
        T GetFor(Guid guid);
    }
}