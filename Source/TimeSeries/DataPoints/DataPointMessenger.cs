/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.Lifecycle;
using Dolittle.TimeSeries.DataPoints;
using Single = Dolittle.TimeSeries.DataTypes.Single;

namespace TimeSeries.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointMessenger"/>
    /// </summary>
    [Singleton]
    public class DataPointMessenger : IDataPointMessenger
    {
        /// <inheritdoc/>
        public event DataPointReady DataPointReady = (d) => {};

        /// <inheritdoc/>
        public void Push(LocationId location, NodeId node, string metricType, double value)
        {
            DataPointReady(new TagDataPoint(metricType, (Single)value));
        }
    }
}