/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Dolittle.Events.Processing;
using Dolittle.Logging;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Locations.Nodes;
using MongoDB.Driver;

namespace Read.Locations.Nodes
{
    public class NodeEventProcessors : ICanProcessEvents
    {
        private readonly ILogger _logger;

        /*
readonly IReadModelRepositoryFor<Node> _nodes;

public NodeEventProcessors(IReadModelRepositoryFor<Node> nodes)
{
this._nodes = nodes;
}*/


        public NodeEventProcessors(ILogger logger)
        {
            _logger = logger;
        }

        [EventProcessor("8c9f4260-52ac-48f2-a99a-1c3829e29b12")]
        public void Process(NodeAddedToLocation @event, EventSourceId id)
        {
            _logger.Information($"Inserting, tenant: '{AllNodes.Tenant}', microservice: '{AllNodes.Microservice}', correlation: '{AllNodes.Correlation}'");


            var url = $"mongodb://{AllNodes.Correlation}.mongo.localhost:27017";
            var settings = MongoClientSettings.FromUrl(new MongoUrl(url));
            settings.UseSsl = true;
            settings.VerifySslCertificate = false;
            var client = new MongoClient(settings);
            var databaseIdentifier = AllNodes.Tenant.Value.ToByteArray().Concat(AllNodes.Microservice.ToByteArray()).ToArray();
            var databaseIdentifierEncoded = Convert.ToBase64String(databaseIdentifier);
            var database = client.GetDatabase(databaseIdentifierEncoded);
            var collectionName = "Locations.Nodes.Node";
            var collection = database.GetCollection<Node>(collectionName);
            collection.InsertOne(new Node()
            {
                Id = id.Value,
                Name = @event.Name
            });


            /*
            _nodes.Insert(new Node()
            {
                Id = id.Value,
                Name = @event.Name
            });*/
        }
    }
}