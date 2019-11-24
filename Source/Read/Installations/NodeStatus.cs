/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class NodeStatus : IReadModel
    {
        public NodeId Id { get; set; }
        public SiteId SiteId {  get; set; }
        public SiteName SiteName { get; set; }
        public InstallationId InstallationId { get; set; }
        public InstallationName InstallationName { get; set; }
        public IDictionary<string, float> Metrics { get; set; }
        public IDictionary<string, string> Infos { get; set; }
        public DateTimeOffset LastSeen { get; set; }
    }
}