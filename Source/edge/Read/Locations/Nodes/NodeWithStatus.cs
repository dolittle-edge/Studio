/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Concepts.Locations.Nodes;
using Concepts.Telemetry;
using Dolittle.ReadModels;

namespace Read.Locations.Nodes
{
    /// <summary>
    /// Represents the status of a node
    /// </summary>
    public class NodeWithStatus : IReadModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the node
        /// </summary>
        public NodeId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the node
        /// </summary>
        public NodeName Name { get; set; }
        
        /// <summary>
        /// Gets or sets the current telemetry state for different <see cref="TelemetryType"/>
        /// </summary>
        public IDictionary<TelemetryType, TelemetrySample> State {  get; set; }

        /// <summary>
        /// Gets or sets the connectivity status for the node
        /// </summary>
        public Connectivity Connectivity { get; set; }

        /// <summary>
        /// Gets or sets the last time the location was updated
        /// </summary>
        public DateTimeOffset LastUpdated { get; set; }
    }
}