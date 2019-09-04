/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace API.Telemetry
{
    /// <summary>
    /// Represents a node on a location
    /// </summary>
    public class NodeTelemetry
    {
        /// <summary>
        /// Gets or sets the unique identifier for the location
        /// </summary>
        public Guid LocationId {  get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the <see cref="NodeTelemetry"/>
        /// </summary>
        public Guid NodeId { get; set; }

        /// <summary>
        /// Gets or sets the key/value of metrics of state being reported
        /// </summary>
        public IDictionary<string, float> Metrics { get; set; }

        /// <summary>
        /// Gets or sets the key/value of infos of state being reported
        /// </summary>
        public IDictionary<string, string> Infos { get; set; }
    }
}