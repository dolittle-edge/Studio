/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts.Locations;
using Concepts.Telemetry;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Mvc;
using Read.Locations;
using Read.Locations.Nodes;
using Dolittle.Execution;

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

        /// <summary>
        /// Initializes a new instance of <see cref="TelemetryController"/>
        /// </summary>
        /// <param name="nodeTelemeter"><see cref="INodeTelemeter"/> for dealing with telemetry for nodes</param>
        /// <param name="locationStatuses"><see cref="ILocationStatuses"/> for dealing with status for locations</param>
        /// <param name="executionContextManager"></param>
        public TelemetryController(
            INodeTelemeter nodeTelemeter,
            ILocationStatuses locationStatuses,
            IExecutionContextManager executionContextManager)
        {
            _nodeTelemeter = nodeTelemeter;
            _locationStatuses = locationStatuses;
            _executionContextManager = executionContextManager;
        }

        /// <summary>
        /// Post node telemetry
        /// </summary>
        /// <param name="nodeTelemetry"><see cref="NodeTelemetry"/> to post</param>
        /// <returns><see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult Post([FromBody] NodeTelemetry nodeTelemetry)
        {
            _nodeTelemeter.Transmit(
                nodeTelemetry.LocationId, 
                nodeTelemetry.NodeId,
                nodeTelemetry.State.ToDictionary(_ => (TelemetryType)_.Key, _ => (TelemetrySample)_.Value)
            );
            _locationStatuses.ReportConnectionFrom(nodeTelemetry.LocationId, nodeTelemetry.NodeId);

            var result = new ContentResult
            {
                ContentType = "application/json",
                StatusCode = 200,
            };

            return result;
        }
    }
}