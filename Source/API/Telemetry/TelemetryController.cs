/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using Dolittle.Collections;
using TimeSeries.DataPoints;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an API controller for telemetry
    /// </summary>
    [Route("api/Telemetry")]
    public class TelemetryController : ControllerBase
    {
        readonly ILocationStatuses _locationStatuses;
        readonly IDataPointMessenger _dataPointMessenger;

        /// <summary>
        /// Initializes a new instance of <see cref="TelemetryController"/>
        /// </summary>
        /// <param name="locationStatuses"><see cref="ILocationStatuses"/> for dealing with status for locations</param>
        /// <param name="dataPointMessenger"><see cref="IDataPointMessenger"/> for dealing with </param>
        public TelemetryController(
            ILocationStatuses locationStatuses,
            IDataPointMessenger dataPointMessenger)
        {
            _locationStatuses = locationStatuses;
            _dataPointMessenger = dataPointMessenger;
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