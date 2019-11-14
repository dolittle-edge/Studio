/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts.Locations;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Read.Locations.Nodes;


namespace Read.Locations
{
    /// <summary>
    /// Represents a query for getting all nodes in a location
    /// </summary>
    public class LocationById : IQueryFor<LocationWithStatus>
    {
        readonly IReadModelRepositoryFor<LocationWithStatus> _locationsWithStatus;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationsWithStatus"></param>
        /// 
        public LocationById(IReadModelRepositoryFor<LocationWithStatus> locationsWithStatus)
        {
            _locationsWithStatus = locationsWithStatus;
        }
        /// <summary>
        /// 
        /// </summary>
        public LocationId LocationId { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<LocationWithStatus> Query => _locationsWithStatus.Query.Where(_=>_.Id == LocationId).AsQueryable();
    }
}