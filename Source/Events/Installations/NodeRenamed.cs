/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class NodeRenamed : IEvent
    {
        public NodeRenamed(Guid nodeId, string name)
        {
            NodeId = nodeId;
            Name = name;
        }

        public Guid NodeId { get; }
        public string Name { get; }
    }
}