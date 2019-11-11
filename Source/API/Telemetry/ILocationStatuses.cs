/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;

namespace API.Telemetry
{
    /// <summary>
    /// Defines a system for maintaining location statuses
    /// </summary>
    public interface ILocationStatuses
    {
        /// <summary>
        /// Report connection from 
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="nodeId"></param>
        void ReportConnectionFrom(LocationId locationId, NodeId nodeId);
    }
}