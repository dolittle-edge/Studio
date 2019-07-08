/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Locations;
using Dolittle.ReadModels;

namespace Read.Locations
{
    /// <summary>
    /// Represents the values for connectivity
    /// </summary>
    public enum Connectivity 
    {
        /// <summary>
        /// When something is connected
        /// </summary>
        Connected,

        /// <summary>
        /// When something is disconnected
        /// </summary>
        Disconnected
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModuleStatus : IReadModel
    {

    }


    /// <summary>
    /// Represents the status of a location
    /// </summary>
    public class LocationStatus : IReadModel
    {
        /// <summary>
        /// Gets or sets the name of the location
        /// </summary>
        public LocationName Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="NodeStatus">status for nodes</see>
        /// </summary>
        public IEnumerable<NodeStatus> Nodes { get; set; }
    }
}