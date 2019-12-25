// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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

        public Guid InstallationId { get; }

        public string Name { get; }
    }
}