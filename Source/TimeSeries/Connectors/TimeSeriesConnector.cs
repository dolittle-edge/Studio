// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.TimeSeries.Connectors;
using Dolittle.TimeSeries.DataPoints;
using TimeSeries.DataPoints;

namespace TimeSeries.Connectors
{
    /// <summary>
    /// Represents a <see cref="IAmAPushConnector"/> for pushing timeseries telemetry.
    /// </summary>
    public class TimeSeriesConnector : IAmAPushConnector, IDisposable
    {
        internal const string SourceName = "EdgeTelemetry";

        readonly ConcurrentQueue<TagDataPoint> _outbox = new ConcurrentQueue<TagDataPoint>();

        readonly AutoResetEvent _waitHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesConnector"/> class.
        /// </summary>
        /// <param name="dataPointMessenger"><see cref="IDataPointMessenger"/> to use.</param>
        public TimeSeriesConnector(IDataPointMessenger dataPointMessenger)
        {
            _waitHandle = new AutoResetEvent(false);

            dataPointMessenger.DataPointReady += (dataPoint) =>
            {
                _outbox.Enqueue(dataPoint);
                _waitHandle.Set();
            };
        }

        /// <inheritdoc/>
        public Source Name => SourceName;

        /// <inheritdoc/>
        public async Task Connect(IStreamWriter writer)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    _waitHandle.WaitOne(1000);
                    if (_outbox.IsEmpty) continue;

                    TagDataPoint dataPoint = null;
                    while (!_outbox.IsEmpty)
                    {
                        if (_outbox.TryDequeue(out dataPoint))
                        {
                            await writer.Write(new[] { dataPoint }).ConfigureAwait(false);
                        }
                    }
                }
            }).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _waitHandle?.Dispose();
        }
    }
}