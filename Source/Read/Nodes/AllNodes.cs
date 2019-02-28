/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.IO.Tenants;
using Dolittle.Queries;
using Dolittle.Serialization.Json;

namespace Read.Nodes
{
    public class AllNodes : IQueryFor<Node>
    {
        const string _nodesFile = "nodes.json";

        readonly ITenantAwareFileSystem _fileSystem;

        public AllNodes(ITenantAwareFileSystem fileSystem, ISerializer serializer)
        {
            _fileSystem = fileSystem;

            if (_fileSystem.Exists(_nodesFile))
            {
                var json = _fileSystem.ReadAllText(_nodesFile);
                Query = serializer.FromJson<IEnumerable<Node>>(json).AsQueryable();
            }
            else
            {
                Query = new Node[0].AsQueryable();
            }

        }

        public IQueryable<Node> Query { get; }
    }
}