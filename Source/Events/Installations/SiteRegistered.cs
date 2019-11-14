/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class SiteRegistered : IEvent
    {
        public SiteRegistered(Guid siteId, string name)
        {
            SiteId = siteId;
            Name = name;
        }

        public Guid SiteId { get; }
        public string Name { get; }
    }
}