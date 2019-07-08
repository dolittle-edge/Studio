/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.Tenancy;
using Read.Locations;

namespace API.Telemetry
{
    /// <summary>
    /// Defines a system for maintaining location statuses
    /// </summary>
    public interface ILocationStatuses
    {
        /// <summary>
        /// Initialize the statuses
        /// </summary>
        void Initialize();

        /// <summary>
        /// Get status for <see cref="TenantId"/>
        /// </summary>
        /// <param name="tenantId"><see cref="TenantId"/> to get for</param>
        IEnumerable<LocationWithStatus> GetFor(TenantId tenantId);

        /// <summary>
        /// Report connection from 
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="nodeId"></param>
        void ReportConnectionFrom(LocationId locationId, NodeId nodeId);
    }
}