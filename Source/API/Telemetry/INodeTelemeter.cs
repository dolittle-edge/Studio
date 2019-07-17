/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Concepts.Telemetry;
using Read.Locations;

namespace API.Telemetry
{
    /// <summary>
    /// Defines a system for working with <see cref="NodeTelemetry"/>
    /// </summary>
    public interface INodeTelemeter
    {
        /// <summary>
        /// Check if there is <see cref="LocationStatus"/> for <see cref="LocationName"/>
        /// </summary>
        /// <param name="name"><see cref="LocationName"/> to get for</param>
        /// <returns>True if there is, false if not</returns>
        bool HasStatusFor(LocationName name);

        /// <summary>
        /// Check if there is <see cref="LocationStatus"/> for <see cref="LocationId"/>
        /// </summary>
        /// <param name="locationId"><see cref="LocationName"/> to get for</param>
        /// <returns>True if there is, false if not</returns>
        bool HasStatusFor(LocationId locationId);

        /// <summary>
        /// Get <see cref="LocationStatus"/> for <see cref="LocationName"/>
        /// </summary>
        /// <param name="name"><see cref="LocationName"/> to get for</param>
        /// <returns>Current <see cref="LocationStatus"/></returns>
        LocationStatus GetStatusFor(LocationName name);

        /// <summary>
        /// Get <see cref="LocationStatus"/> for <see cref="LocationId"/>
        /// </summary>
        /// <param name="locationId">Location by <see cref="LocationId"/> to get for</param>
        /// <returns>Current <see cref="LocationStatus"/></returns>
        LocationStatus GetStatusFor(LocationId locationId);

        /// <summary>
        /// Transmit telemetry for a node at a location
        /// </summary>
        /// <param name="location"><see cref="LocationId"/> for the node</param>
        /// <param name="node"><see cref="NodeId"/> for the node</param>
        /// <param name="state">Actual state to transmit</param>
        void Transmit(LocationId location, NodeId node, IDictionary<TelemetryType, TelemetrySample> state);
    }
}