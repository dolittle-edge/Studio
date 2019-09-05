/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Security.Cryptography;
using Concepts.Locations.Nodes;
using Dolittle.Logging;
using Dolittle.Serialization.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Provisioning
{
    /// <summary>
    /// Represents an API controller for provisioning
    /// </summary>
    [Route("api/Provisioning")]
    public class ProvisioningController : ControllerBase
    {
        readonly IConfigurationProvider _provider;
        readonly ISerializer _serializer;
        readonly ILogger _logger;

        /// <summary>
        /// Creates an instance of <see cref="ProvisioningController"/>
        /// </summary>
        public ProvisioningController(IConfigurationProvider provider, ISerializer serializer, ILogger logger)
        {
            _provider = provider;
            _serializer = serializer;
            _logger = logger;
        }

        /// <summary>
        /// Get the Edge Agent configuration for a node
        /// </summary>
        /// <param name="information"><see cref="SystemInformation"/> describing the node requesting Edge Agent configuration</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPost("Get")]
        public IActionResult GetConfiguration([FromBody] SystemInformation information)
        {
            _logger.Information($"Getting Edge Agent configuration for node '{information.SerialNumber}'");

            var status = _provider.GetProvisioningStatusForNode(information);
            switch (status)
            {
                //case ProvisioningStatus.NotConfigured:
                default:
                    return NotFound();

                case ProvisioningStatus.Revoked:
                    return Unauthorized();

                case ProvisioningStatus.Configured:
                    var configuration = _provider.GetConfigurationForNode(information);
                    var json = _serializer.ToJson(configuration);
                    return Content(json, "application/json");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPost("Check")]
        public IActionResult CheckForConfigurationUpdates([FromForm] Guid nodeId, [FromForm] string hash)
        {
            _logger.Information($"Checking for updates to Edge Agent configuration for node '{nodeId}', current configuration hash '{hash}'");

            var status = _provider.GetProvisioningStatusForNodeById(nodeId);
            switch (status)
            {
                //case ProvisioningStatus.NotConfigured:
                default:
                    return NotFound();

                case ProvisioningStatus.Revoked:
                    return Unauthorized();

                case ProvisioningStatus.Configured:
                    var configuration = _provider.GetConfigurationForNodeById(nodeId);
                    if (ComputeConfigurationHash(configuration).Equals(hash))
                    {
                        return StatusCode(304);
                    }
                    else
                    {
                        var jsonr = _serializer.ToJson(configuration);
                        return Content(jsonr, "application/json");
                    }
            }
        }

        string ComputeConfigurationHash(NodeConfiguration configuration)
        {
            using (var json = _serializer.ToJsonStream(configuration, SerializationOptions.Custom(SerializationOptionsFlags.None)))
            using (var hasher = new SHA256Managed())
            {
                var data = hasher.ComputeHash(json);
                return Convert.ToBase64String(data);
            }
        }
    }
}