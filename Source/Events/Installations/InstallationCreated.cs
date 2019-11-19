/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class InstallationCreated : IEvent
    {
        public InstallationCreated(Guid installationId, string siteName, string name)
        {
            SiteName = siteName;
            InstallationId = installationId;
            Name = name;
        }

        public Guid InstallationId { get; }

        public string SiteName { get; }

        public string Name { get; }
    }
}