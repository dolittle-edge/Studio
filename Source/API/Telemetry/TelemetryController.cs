/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts.Telemetry;
using Microsoft.AspNetCore.Mvc;
using Dolittle.Execution;
using Dolittle.Collections;

namespace API.Telemetry
{
    /// <summary>
    /// Represents an API controller for telemetry
    /// </summary>
    [Route("api/Telemetry")]
    public class TelemetryController : ControllerBase
    {
        readonly INodeTelemeter _nodeTelemeter;
        readonly ILocationStatuses _locationStatuses;
        readonly IExecutionContextManager _executionContextManager;
        readonly IDataPointQueue _dataPointQueue;

        /// <summary>
        /// Initializes a new instance of <see cref="TelemetryController"/>
        /// </summary>
        /// <param name="nodeTelemeter"><see cref="INodeTelemeter"/> for dealing with telemetry for nodes</param>
        /// <param name="locationStatuses"><see cref="ILocationStatuses"/> for dealing with status for locations</param>
        /// <param name="dataPointQueue"></param>
        /// <param name="executionContextManager"></param>
        public TelemetryController(
            INodeTelemeter nodeTelemeter,
            ILocationStatuses locationStatuses,
            IDataPointQueue dataPointQueue,
            IExecutionContextManager executionContextManager)
        {
            _nodeTelemeter = nodeTelemeter;
            _locationStatuses = locationStatuses;
            _executionContextManager = executionContextManager;
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

            _nodeTelemeter.Transmit(
                nodeTelemetry.LocationId,
                nodeTelemetry.NodeId,
                nodeTelemetry.Metrics.ToDictionary(_ => (MetricType)_.Key, _ => (Metric)_.Value),
                nodeTelemetry.Infos.ToDictionary(_ => (InfoType)_.Key, _ => (Info)_.Value)
            );
            _locationStatuses.ReportConnectionFrom(nodeTelemetry.LocationId, nodeTelemetry.NodeId);

            return new ContentResult
            {
                ContentType = "application/json",
                StatusCode = 200,
            };
        }
    }
}