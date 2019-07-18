/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Locations;

namespace Read.Locations
{
    public class LocationEventProcessors : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Location> _repositoryForLocation;

        public LocationEventProcessors(
            IReadModelRepositoryFor<Location> repositoryForLocation            
        )
        {
            _repositoryForLocation = repositoryForLocation;
        }
        
        [EventProcessor("1d670546-bb06-7cbf-d038-e1d2882b19b7")]
        public void Process(LocationAdded @event, EventSourceId locationId)
        { 
            _repositoryForLocation.Insert(new Location()
            {
                Id = locationId.Value,
                Name = @event.Name
            });
        }
        
    }
}
