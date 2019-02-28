/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Node node)
        {
            var nodes = new List<Node>(GetAllNodes());
            nodes.Add(node);
            var json = _serializer.ToJson(nodes);
            _fileSystem.WriteAllText(_nodesFile, json);
        }

        public IEnumerable<Node> GetAllNodes()
        {            
            if (_fileSystem.Exists(_nodesFile))
            {
                var json = _fileSystem.ReadAllText(_nodesFile);
                return _serializer.FromJson<IEnumerable<Node>>(json).AsQueryable();
            }
            return new Node[0].AsQueryable();
        }
    }
}