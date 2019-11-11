/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Concepts.Locations;
using Concepts.Locations.Nodes;

namespace API.Provisioning
{
    /// <summary>
    /// Represents configuration for the EdgeAgent on a node
    /// </summary>
    public class NodeConfiguration
    {
        /// <summary>
        /// The unique identifier for the location where the node resides
        /// </summary>
        public LocationId LocationId { get; set; }

        /// <summary>
        /// The unique identifier of the node
        /// </summary>
        public NodeId NodeId { get; set; }

        /// <summary>
        /// Configurations for the Edge Agent to apply to low-level systems on the node
        /// </summary>
        public IDictionary<string,object> Configuration { get; set; }
    }
}