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
    public class NodeManager : INodeManager
    {
        const string _nodesFile = "nodes.json";
        readonly ITenantAwareFileSystem _fileSystem;
        readonly ISerializer _serializer;

        public NodeManager(ITenantAwareFileSystem fileSystem, ISerializer serializer)
        {
            _fileSystem = fileSystem;
            _serializer = serializer;
        }

        public void Add(LocationId locationId, Node node)
        {
            var nodes = new List<Node>(GetAllNodesFor(locationId));
            nodes.Add(node);
            var json = _serializer.ToJson(nodes);
            _fileSystem.WriteAllText(_nodesFile, json);
        }

        public IEnumerable<Node> GetAllNodesFor(LocationId locationId)
        {       
            var path = Path.Combine(locationId.ToString(),_nodesFile);     
            if (_fileSystem.Exists(path))
            {
                var json = _fileSystem.ReadAllText(path);
                return _serializer.FromJson<IEnumerable<Node>>(json).AsQueryable();
            }
            return new Node[0].AsQueryable();
        }
    }
}