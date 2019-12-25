// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using Dolittle.Lifecycle;
using MongoDB.Driver;

namespace Infrastructure.Domain
{
    /// <summary>
    /// Represents an implementation of <see cref="INaturalKeysOf{T}"/>.
    /// </summary>
    /// <typeparam name="TKey">Type of key.</typeparam>
    [SingletonPerTenant]
    public class NaturalKeysOf<TKey> : INaturalKeysOf<TKey>
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<NaturalKeyMap<TKey>> _collection;
        readonly ConcurrentDictionary<TKey, Guid> _keysToGuids = new ConcurrentDictionary<TKey, Guid>();
        readonly ConcurrentDictionary<Guid, TKey> _guidsToKeys = new ConcurrentDictionary<Guid, TKey>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NaturalKeysOf{T}"/> class.
        /// </summary>
        /// <param name="database"><see cref="IMongoDatabase"/>.</param>
        public NaturalKeysOf(IMongoDatabase database)
        {
            _database = database;
            _collection = GetCollection();
            Populate();
        }

        /// <inheritdoc/>
        public void Associate(TKey key, Guid guid)
        {
            var association = new NaturalKeyMap<TKey> { Id = guid, Key = key };
            _collection.ReplaceOne(
                map => map.Id == association.Id,
                association,
                new UpdateOptions { IsUpsert = true });

            if (_keysToGuids.Any(_ => _.Value == guid))
            {
                var existing = _keysToGuids.SingleOrDefault(_ => _.Value == guid);
                _keysToGuids.TryRemove(existing.Key, out Guid existingGuid);
            }

            _keysToGuids[key] = guid;
            _guidsToKeys[guid] = key;
        }

        /// <inheritdoc/>
        public Guid GetFor(TKey key)
        {
            ThrowIfMissingGuidForNaturalKey(key);
            return _keysToGuids[key];
        }

        /// <inheritdoc/>
        public TKey GetFor(Guid guid)
        {
            ThrowIfMissingNaturalKeyForGuid(guid);
            return _guidsToKeys[guid];
        }

        void Populate()
        {
            var maps = _collection.Find(_ => true).ToList();
            maps.ForEach(_ =>
            {
                _keysToGuids[_.Key] = _.Id;
                _guidsToKeys[_.Id] = _.Key;
            });
        }

        string GetFeatureName()
        {
            return string.Join(".", typeof(TKey).Namespace.Split('.').Skip(1));
        }

        IMongoCollection<NaturalKeyMap<TKey>> GetCollection()
        {
            var collection = $"NaturalKeysOf_{GetFeatureName()}.{typeof(TKey).Name}";
            return _database.GetCollection<NaturalKeyMap<TKey>>(collection);
        }

        void ThrowIfMissingGuidForNaturalKey(TKey key)
        {
            if (!_keysToGuids.ContainsKey(key)) throw new MissingGuidForNaturalKey(key);
        }

        void ThrowIfMissingNaturalKeyForGuid(Guid guid)
        {
            if (!_guidsToKeys.ContainsKey(guid)) throw new MissingNaturalKeyForGuid(guid);
        }
    }
}