/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts.Locations;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Locations
{
    public class LocationById : IQueryFor<Location>
    {
        readonly IReadModelRepositoryFor<Location> _repositoryForLocation;

        public LocationById(IReadModelRepositoryFor<Location> repositoryForLocation)
        {
            _repositoryForLocation = repositoryForLocation;
        }

        public LocationId Id {get; set;}
        public IQueryable<Location> Query => _repositoryForLocation.Query.Where(_ => _.Id == Id);
    }
}
