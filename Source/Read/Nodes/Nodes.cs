/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts.Locations;
using Dolittle.IO.Tenants;
using Dolittle.Serialization.Json;

namespace Read.Nodes
{
    public class Nodes : INodes
    {
        const string _nodesFile = "nodes.json";
        readonly ITenantAwareFileSystem _fileSystem;
        readonly ISerializer _serializer;

        public Nodes(ITenantAwareFileSystem fileSystem, ISerializer serializer)
        {
            _fileSystem = fileSystem;
            _serializer = serializer;
        }

        public void Add(LocationId locationId, Node node)
        {
            var path = GetNodesPathFor(locationId);
            var nodes = new List<Node>(GetAllNodesFor(locationId));
            nodes.Add(node);
            var json = _serializer.ToJson(nodes);
            _fileSystem.WriteAllText(path, json);
        }

        public IEnumerable<Node> GetAllNodesFor(LocationId locationId)
        {       
            var path = GetNodesPathFor(locationId);
            if (_fileSystem.Exists(path))
            {
                var json = _fileSystem.ReadAllText(path);
                return _serializer.FromJson<IEnumerable<Node>>(json).AsQueryable();
            }
            return new Node[0].AsQueryable();
        }


        string GetNodesPathFor(LocationId locationId)
        {
            return Path.Combine(locationId.ToString(),_nodesFile);
        }
    }
}