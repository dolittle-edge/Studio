// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Collections;
using Microsoft.AspNetCore.Mvc;
using Read.Installations;
using TimeSeries.DataPoints;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an API controller for telemetry.
    /// </summary>
    [Route("api/Telemetry")]
    public class TelemetryController : ControllerBase
    {
        readonly IDataPointMessenger _dataPointMessenger;
        private readonly ICurrentNodeStatus _currentNodeStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryController"/> class.
        /// </summary>
        /// <param name="dataPointMessenger"><see cref="IDataPointMessenger"/> for dealing with.</param>
        /// <param name="currentNodeStatus"><see cref="ICurrentNodeStatus"/> for reporting current status of nodes.</param>
        public TelemetryController(
            IDataPointMessenger dataPointMessenger,
            ICurrentNodeStatus currentNodeStatus)
        {
            _dataPointMessenger = dataPointMessenger;
            _currentNodeStatus = currentNodeStatus;
        }

        /// <summary>
        /// [POST} Action for posting node telemetry.
        /// </summary>
        /// <param name="nodeTelemetry"><see cref="NodeTelemetry"/> to post.</param>
        /// <returns><see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] NodeTelemetry nodeTelemetry)
        {
            nodeTelemetry.Metrics.ForEach(_ =>
            {
                _dataPointMessenger.Push(
                    nodeTelemetry.SiteId,
                    nodeTelemetry.InstallationId,
                    nodeTelemetry.NodeId,
                    _.Key,
                    _.Value);
            });

            _currentNodeStatus.Report(
                nodeTelemetry.SiteId,
                nodeTelemetry.InstallationId,
                nodeTelemetry.NodeId,
                nodeTelemetry.Metrics,
                nodeTelemetry.Infos);

            return new ContentResult
            {
                ContentType = "application/json",
                StatusCode = 200,
            };
        }
    }
}