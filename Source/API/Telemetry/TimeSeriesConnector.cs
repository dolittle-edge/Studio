/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.TimeSeries.Connectors;
using Dolittle.TimeSeries.DataPoints;


namespace API.Telemetry
{
    /// <summary>
    /// Represents a <see cref="IAmAPushConnector"/> for pushing timeseries telemetry
    /// </summary>
    public class TimeSeriesConnector : IAmAPushConnector
    {
        readonly ConcurrentQueue<TagDataPoint> _outbox = new ConcurrentQueue<TagDataPoint>();

        readonly AutoResetEvent _waitHandle;

        /// <summary>
        /// Initializes a new instance of <see cref="TimeSeriesConnector"/>
        /// </summary>
        public TimeSeriesConnector(IDataPointQueue dataPointQueue)
        {
            _waitHandle = new AutoResetEvent(false);

            dataPointQueue.DataPointReady += (dataPoint) =>
            {
                _outbox.Enqueue(dataPoint);
                _waitHandle.Set();
            };
        }

        /// <inheritdoc/>
        public Source Name => "TimeSeriesConnector";

        /// <inheritdoc/>
        public async Task Connect(IStreamWriter writer)
        {
            await Task.Run(async () =>
            {
                for (; ; )
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
    }
}