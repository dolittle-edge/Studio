/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using API.Telemetry;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Mvc;
using Read.Locations;
using Dolittle.Logging;

namespace API.Locations
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Locations")]
    public class LocationsController : ControllerBase
    {
        readonly ISerializer _serializer;
        readonly INodeTelemeter _nodeTelemeter;
        readonly ILocationStatuses _locationStatuses;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="LocationsController"/>
        /// </summary>
        /// <param name="serializer"><see cref="ISerializer"/> used for serializing and deserializing JSON</param>
        /// <param name="nodeTelemeter"></param>
        /// <param name="locationStatuses"></param>
        /// <param name="logger"></param>
        public LocationsController(
            ISerializer serializer,
            INodeTelemeter nodeTelemeter,
            ILocationStatuses locationStatuses,
            ILogger logger)
        {
            _serializer = serializer;
            _nodeTelemeter = nodeTelemeter;
            _locationStatuses = locationStatuses;
            _logger = logger;
        }

        /// <summary>
        /// Get list of <see cref="Location"/>
        /// </summary>
        /// <returns>A JSON reprentation of <see cref="LocationStatus"/></returns>
        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            var statuses = _locationStatuses.GetFor(TenantId.Development);
            var json = _serializer.ToJson(statuses, SerializationOptions.CamelCase);

            var result = new ContentResult
            {
                ContentType = "application/json",
                StatusCode = 200,
                Content = json
            };
            return result;
        }

        /// <summary>
        /// Get <see cref="LocationStatus"/>
        /// </summary>
        /// <param name="name">Name of location</param>
        /// <returns>A JSON reprentation of <see cref="LocationStatus"/></returns>
        [HttpGet]
        [Route("{name}")]
        public ActionResult Get([FromRoute] string name)
        {
            _logger.Information($"Get information about location called '{name}'");
            if (_nodeTelemeter.HasStatusFor(name))
            {
                var status = _nodeTelemeter.GetStatusFor(name);
                var result = new ContentResult
                {
                    ContentType = "application/json",
                    StatusCode = 200,
                    Content = _serializer.ToJson(status, SerializationOptions.CamelCase)
                };

                return result;
            }

            return new ContentResult
            {
                ContentType = "application/text",
                    StatusCode = 404,
                    Content = $"Location '{name}' does not exist"
            };
        }
    }
}