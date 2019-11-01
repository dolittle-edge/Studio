/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Locations
{
    public class LocationCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Location> _repository;

        public LocationCommandHandlers(IAggregateRootRepositoryFor<Location> repository)
        {
            _repository = repository;
        }
        public void Handle(AddLocation command)
        {
            _repository.Get(command.LocationId).Create(command.Name);
        }
    }
}