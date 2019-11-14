/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Locations.Nodes;

namespace Read.Locations.Nodes
{
    /// <summary>
    /// LocationEventProcessor process events for locations
    /// </summary>
    public class NodeEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Node> _nodes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public NodeEventProcessor(IReadModelRepositoryFor<Node> nodes)
        {
            _nodes = nodes;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("18e9cc1a-4d54-48a8-9021-54af0ce794a3")]
        public void Process(NodeAdded @event, EventMetadata eventMetadata)
        {
            _nodes.Insert(new Node
            {
                Id = (Guid)eventMetadata.EventSourceId,
                Name = @event.Name,
                LocationId = @event.LocationId,
            });
        }
    }
}