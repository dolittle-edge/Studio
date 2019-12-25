// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.TimeSeries.DataPoints;

namespace TimeSeries.DataPoints
{
    /// <summary>
    /// Represents a callback for when a <see cref="TagDataPoint"/> is ready.
    /// </summary>
    /// <param name="dataPoint"><see cref="TagDataPoint"/>.</param>
    public delegate void DataPointReady(TagDataPoint dataPoint);
}