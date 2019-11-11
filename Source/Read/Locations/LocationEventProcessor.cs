/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.Locations.Nodes;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Locations;
using Events.Locations.Nodes;

namespace Read.Locations
{
    /// <summary>
    /// LocationEventProcessor process events for locations
    /// </summary>
    public class LocationEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Location> _locations;
        readonly IReadModelRepositoryFor<LocationWithStatus> _locationsWithStatus;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="locationsWithStatus"></param>
        public LocationEventProcessor(IReadModelRepositoryFor<Location> locations, IReadModelRepositoryFor<LocationWithStatus> locationsWithStatus)
        {
            _locations = locations;
            _locationsWithStatus = locationsWithStatus;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("f98ba9f3-12a1-4f47-966e-892aad577da2")]
        public void Process(LocationAdded @event, EventMetadata eventMetadata)
        {
            _locations.Insert(new Location
            {
                Id = (Guid)eventMetadata.EventSourceId,
                Name = @event.Name,
            });
            _locationsWithStatus.Insert(new LocationWithStatus{
                Id = (Guid)eventMetadata.EventSourceId,
                Name = @event.Name,
                Nodes = new List<NodeName>(),
                HasBeenSeen = false,
            });
        }

        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("97867397-5783-4cca-aca4-8b9774ca8a49")]
        public void Process(NodeAdded @event, EventMetadata eventMetadata)
        {
            var location = _locationsWithStatus.GetById(@event.LocationId);
            location.Nodes.Add(@event.Name);
            location.TotalNodes += 1;
            _locationsWithStatus.Update(location);
        }
    }
}