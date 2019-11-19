/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Concurrent;
using System.Linq;
using Dolittle.Lifecycle;
using MongoDB.Driver;

namespace Infrastructure.Domain
{
    /// <summary>
    /// Represents an implementation of <see cref="INaturalKeysOf{T}"/>
    /// </summary>
    [SingletonPerTenant]
    public class NaturalKeysOf<T> : INaturalKeysOf<T>
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<NaturalKeyMap<T>> _collection;
        readonly ConcurrentDictionary<T, Guid> _keysToGuids = new ConcurrentDictionary<T, Guid>();
        readonly ConcurrentDictionary<Guid, T> _guidsToKeys = new ConcurrentDictionary<Guid, T>();

        /// <summary>
        /// Initializes a new instance of <see cref="NaturalKeysOf{T}"/>
        /// </summary>
        /// <param name="database"><see cref="IMongoDatabase"/></param>
        public NaturalKeysOf(IMongoDatabase database)
        {
            _database = database;
            _collection = GetCollection();
            Populate();
        }

        /// <inheritdoc/>
        public void Associate(T key, Guid guid)
        {
            var association = new NaturalKeyMap<T> { Id = guid, Key = key };
            _collection.ReplaceOne(
                map => map.Id == association.Id,
                association,
                new UpdateOptions { IsUpsert = true }
            );

            if (_keysToGuids.Any(_ => _.Value == guid))
            {
                var existing = _keysToGuids.SingleOrDefault(_ => _.Value == guid);
                _keysToGuids.TryRemove(existing.Key, out Guid existingGuid);
            }

            _keysToGuids[key] = guid;
            _guidsToKeys[guid] = key;
        }

        /// <inheritdoc/>
        public Guid GetFor(T key)
        {
            ThrowIfMissingGuidForNaturalKey(key);
            return _keysToGuids[key];
        }

        /// <inheritdoc/>
        public T GetFor(Guid guid)
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
            return string.Join(".", typeof(T).Namespace.Split('.').Skip(1));
        }

        IMongoCollection<NaturalKeyMap<T>> GetCollection()
        {
            var collection = $"NaturalKeysOf_{GetFeatureName()}.{typeof(T).Name}";
            return _database.GetCollection<NaturalKeyMap<T>>(collection);
        }

        void ThrowIfMissingGuidForNaturalKey(T key)
        {
            if (!_keysToGuids.ContainsKey(key)) throw new MissingGuidForNaturalKey(key);
        }

        void ThrowIfMissingNaturalKeyForGuid(Guid guid)
        {
            if (!_guidsToKeys.ContainsKey(guid)) throw new MissingNaturalKeyForGuid(guid);
        }
    }
}