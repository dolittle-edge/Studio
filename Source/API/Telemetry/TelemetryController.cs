/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using Dolittle.Collections;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an API controller for telemetry
    /// </summary>
    [Route("api/Telemetry")]
    public class TelemetryController : ControllerBase
    {
        readonly ILocationStatuses _locationStatuses;
        readonly IDataPointMessenger _dataPointQueue;

        /// <summary>
        /// Initializes a new instance of <see cref="TelemetryController"/>
        /// </summary>
        /// <param name="locationStatuses"><see cref="ILocationStatuses"/> for dealing with status for locations</param>
        /// <param name="dataPointQueue"><see cref="IDataPointQueue"/> for dealing with </param>
        public TelemetryController(
            ILocationStatuses locationStatuses,
            IDataPointMessenger dataPointQueue)
        {
            _locationStatuses = locationStatuses;
            _dataPointQueue = dataPointQueue;
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
                _dataPointQueue.Push(
                    nodeTelemetry.LocationId,
                    nodeTelemetry.NodeId,
                    _.Key,
                    _.Value
                );
            });

            _locationStatuses.ReportConnectionFrom(nodeTelemetry.LocationId, nodeTelemetry.NodeId);

            return new ContentResult
            {
                ContentType = "application/json",
                StatusCode = 200,
            };
        }
    }
}