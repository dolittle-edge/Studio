/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Locations;

namespace Read.Locations
{
    /// <summary>
    /// LocationEventProcessor process events for locations
    /// </summary>
    public class LocationEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Location> _locations;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locations"></param>
        public LocationEventProcessor(IReadModelRepositoryFor<Location> locations)
        {
            _locations = locations;
        }
        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("f98ba9f3-12a1-4f47-966e-892aad577da2")]
        public void Process(LocationCreated @event, EventMetadata eventMetadata)
        {
            _locations.Insert(new Location{
                Id = (Guid)eventMetadata.EventSourceId,
                Name = @event.Name,
            });
        }
    }
}