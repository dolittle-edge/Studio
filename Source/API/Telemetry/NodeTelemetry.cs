/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Installations;

namespace API.Telemetry
{
    /// <summary>
    /// Represents a node within an installation at a site
    /// </summary>
    public class NodeTelemetry
    {
        /// <summary>
        /// Gets or sets the unique identifier of the site
        /// </summary>
        public SiteId SiteId {  get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the installation
        /// </summary>
        public InstallationId InstallationId {  get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the <see cref="NodeTelemetry"/>
        /// </summary>
        public NodeId NodeId { get; set; }

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
