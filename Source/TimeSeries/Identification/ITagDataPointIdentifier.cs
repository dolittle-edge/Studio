/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;

namespace TimeSeries.Identification
{
    /// <summary>
    /// Defines a system for working with identification related to TagDataPoints for our specific
    /// TimeSeries
    /// </summary>
    public interface ITagDataPointIdentifier
    {
        /// <summary>
        /// Get or update the identification of a metric type on a <see cref="NodeId">node</see>
        /// at a <see cref="LocationId">location</see>
        /// </summary>
        /// <param name="location"><see cref="LocationId"/> for the tag</param>
        /// <param name="node"><see cref="NodeId"/> for the tag</param>
        /// <param name="metricType">The type of metric</param>
        /// <returns><see cref="string"/> with the tag name</returns>
        TagToTimeSeries GetOrUpdate(LocationId location, NodeId node, string metricType);
    }
}