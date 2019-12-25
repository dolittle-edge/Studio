// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class NodeRegisteredWithInstallation : IEvent
    {
        public NodeRegisteredWithInstallation(Guid siteId, Guid installationId, Guid nodeId, string name)
        {
            SiteId = siteId;
            NodeId = nodeId;
            Name = name;
            InstallationId = installationId;
        }

        public Guid SiteId { get; }

        public Guid InstallationId { get; }

        public Guid NodeId { get; }

        public string Name { get; }
    }
}