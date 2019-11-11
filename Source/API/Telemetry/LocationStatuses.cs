/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an implementation of <see cref="ILocationStatuses"/>
    /// </summary>
    public class LocationStatuses : ILocationStatuses
    {
        /// <inheritdoc/>
        public void ReportConnectionFrom(LocationId locationId, NodeId nodeId)
        {
        }
   }
}