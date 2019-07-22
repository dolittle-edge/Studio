/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Text;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Dolittle.Tenancy;
using MongoDB.Driver;

namespace Read.Locations.Nodes
{
    public class AllNodes : IQueryFor<Node>
    {
        public static TenantId Tenant {  get; set; }
        public static string Correlation {  get; set; }
        public static Guid Microservice {  get; set; }
        readonly IMongoDatabase _database;
        readonly IMongoCollection<Node> _collection;

        string _collectionName = typeof(Node).FullName;

        readonly IReadModelRepositoryFor<Node> _nodes;

        public AllNodes(IReadModelRepositoryFor<Node> nodes)
        {
            _nodes = nodes;

            var url = $"mongodb://{Correlation}.mongo.localhost:27017";
            var settings = MongoClientSettings.FromUrl(new MongoUrl(url));
            settings.UseSsl = true;
            settings.VerifySslCertificate = false;
            var client = new MongoClient(settings);
            var databaseIdentifier = Tenant.Value.ToByteArray().Concat(Microservice.ToByteArray()).ToArray();
            var databaseIdentifierEncoded = Convert.ToBase64String(databaseIdentifier);
            _database = client.GetDatabase(databaseIdentifierEncoded);
            _collectionName = _collectionName.StartsWith("Read.") ? _collectionName.Substring(5) : _collectionName;
            _collection = _database.GetCollection<Node>(_collectionName);
        }

        public IQueryable<Node> Query => _collection.AsQueryable();
        //_nodes.Query;
    }
}