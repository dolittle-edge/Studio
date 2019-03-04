/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events.Processing;
using Dolittle.IO.Tenants;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Nodes;

namespace Read.Nodes
{
    public class NodeEventProcessors : ICanProcessEvents
    {
        readonly INodes nodes;

        public NodeEventProcessors(INodes nodes)
        {
            this.nodes = nodes;
        }

        [EventProcessor("191e2a46-3769-ec50-a2b7-e4bd027ab15f")]
        public void Process(NodeAdded @event, EventSourceId id)
        {

            nodes.Add(
                Guid.Parse("1c8aa985-5350-4b69-aa43-e6c761b97d01"),
                new Node
                {
                    Id = id.Value,
                        Name = @event.Name
                }
            );
        }
    }
}