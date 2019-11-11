/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.TimeSeries.Connectors;
using Dolittle.TimeSeries.DataPoints;

namespace TimeSeries.DataPoints
{
    /// <summary>
    /// Defines a <see cref="IAmAPushConnector"/> for pushing timeseries telemetry
    /// </summary>
    public interface IDataPointMessenger
    {
        /// <summary>
        /// Event that gets fired when a <see cref="TagDataPoint"/> is ready
        /// </summary>
        event DataPointReady  DataPointReady;

        /// <summary>
        /// Transmit telemetry for a node at a location
        /// </summary>
        /// <param name="location"><see cref="LocationId"/> for the node</param>
        /// <param name="node"><see cref="NodeId"/> for the node</param>
        /// <param name="metricType">Type of metric to push</param>
        /// <param name="value">Value for the metric to push</param>
        void Push(LocationId location, NodeId node, string metricType, double value);
    }
}