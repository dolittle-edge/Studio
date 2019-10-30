/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Concepts.Telemetry;
using Dolittle.TimeSeries.Connectors;
using Dolittle.TimeSeries.DataPoints;

namespace API.Telemetry
{
    /// <summary>
    /// Defines a <see cref="IAmAPushConnector"/> for pushing timeseries telemetry
    /// </summary>
    public interface IDataPointQueue
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
        /// <param name="metricType"><see cref="MetricType"/> to push</param>
        /// <param name="value">Value for the metric to push</param>
        void Push(LocationId location, NodeId node, MetricType metricType, double value);
    }
}