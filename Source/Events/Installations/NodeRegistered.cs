// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class NodeRegistered : IEvent
    {
        public NodeRegistered(Guid nodeId, string name)
        {
            NodeId = nodeId;
            Name = name;
        }

        public Guid NodeId { get; }

        public string Name { get; }
    }
}