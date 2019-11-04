/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Locations
{
    /// <summary>
    /// Represents a query for getting all locactions
    /// </summary>
    public class AllLocations : IQueryFor<Location>
    {
        readonly IReadModelRepositoryFor<Location> _locations;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locations"></param>
        public AllLocations(IReadModelRepositoryFor<Location> locations)
        {
            _locations = locations;
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Location> Query => _locations.Query;
    }
}