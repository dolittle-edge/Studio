/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
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

        public Guid SiteId { get; }
        public Guid InstallationId { get; }

        public Guid NodeId { get; }
        public string Name { get; }
    }
}