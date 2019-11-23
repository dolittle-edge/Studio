/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using Dolittle.Collections;
using TimeSeries.DataPoints;
using Dolittle.Execution;
using Dolittle.Tenancy;
using Read.Installations;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an API controller for telemetry
    /// </summary>
    [Route("api/Telemetry")]
    public class TelemetryController : ControllerBase
    {
        readonly IDataPointMessenger _dataPointMessenger;
        private readonly ICurrentNodeStatus _currentNodeStatus;

        /// <summary>
        /// Initializes a new instance of <see cref="TelemetryController"/>
        /// </summary>
        /// <param name="dataPointMessenger"><see cref="IDataPointMessenger"/> for dealing with </param>
        /// <param name="currentNodeStatus"><see cref="ICurrentNodeStatus"/> for reporting current status of nodes</param>
        public TelemetryController(
            IDataPointMessenger dataPointMessenger,
            ICurrentNodeStatus currentNodeStatus)
        {
            _dataPointMessenger = dataPointMessenger;
            _currentNodeStatus = currentNodeStatus;
        }

        /// <summary>
        /// Post node telemetry
        /// </summary>
        /// <param name="nodeTelemetry"><see cref="NodeTelemetry"/> to post</param>
        /// <returns><see cref="ActionResult"/></returns>
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
                    _.Value
                );
            });

            _currentNodeStatus.Report(
                nodeTelemetry.SiteId,
                nodeTelemetry.InstallationId,
                nodeTelemetry.NodeId,
                nodeTelemetry.Metrics,
                nodeTelemetry.Infos
            );

            return new ContentResult
            {
                ContentType = "application/json",
                StatusCode = 200,
            };
        }
    }
}