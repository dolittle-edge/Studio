/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Locations
{
    public class AllLocations : IQueryFor<Location>
    {
        readonly IReadModelRepositoryFor<Location> _repositoryForLocation;

        public AllLocations(IReadModelRepositoryFor<Location> repositoryForLocation)
        {
            _repositoryForLocation = repositoryForLocation;
        }

        public IQueryable<Location> Query => _repositoryForLocation.Query;
    }
}
