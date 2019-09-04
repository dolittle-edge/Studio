/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Concepts.Locations.Nodes;
using Concepts.Telemetry;
using Dolittle.ReadModels;

namespace Read.Locations
{
    /// <summary>
    /// Represents the status of a node
    /// </summary>
    public class NodeStatus : IReadModel
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
        /// Gets or sets the current metric states for different <see cref="MetricType"/>
        /// </summary>
        public IDictionary<MetricType, Metric> Metrics {  get; set; }

        /// <summary>
        /// Gets or sets the current info states for different <see cref="InfoType"/>
        /// </summary>
        public IDictionary<InfoType, Info> Infos {  get; set; }

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