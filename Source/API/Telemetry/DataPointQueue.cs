/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Concepts.Telemetry;
using Dolittle.Lifecycle;
using Dolittle.TimeSeries.DataPoints;
using Single = Dolittle.TimeSeries.DataTypes.Single;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointQueue"/>
    /// </summary>
    [Singleton]
    public class DataPointQueue : IDataPointQueue
    {
        /// <inheritdoc/>
        public event DataPointReady DataPointReady = (d) => {};

        /// <inheritdoc/>
        public void Push(LocationId location, NodeId node, MetricType metricType, double value)
        {
            DataPointReady(new TagDataPoint(metricType.Value, (Single)value));
        }
    }
}