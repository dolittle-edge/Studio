/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class NodeRegisteredToInstallation : IEvent
    {
        public NodeRegisteredToInstallation(Guid nodeId, string name, Guid installationId)
        {
            NodeId = nodeId;
            Name = name;
            InstallationId = installationId;
        }

        public Guid NodeId { get; }
        public string Name { get; }
        public Guid InstallationId { get; }
    }
}