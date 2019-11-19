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
        public InstallationCreated(Guid installationId, string name, Guid siteId)
        {
            InstallationId = installationId;
            Name = name;
            SiteId = siteId;
        }

        public Guid InstallationId { get; }
        public string Name { get; }
        public Guid SiteId { get; }
    }
}