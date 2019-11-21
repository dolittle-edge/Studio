/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class InstallationRenamed : IEvent
    {
        public InstallationRenamed(Guid installationId, string name)
        {
            InstallationId = installationId;
            Name = name;
        }

        public Guid InstallationId { get; }
        public string Name { get; }
    }
}