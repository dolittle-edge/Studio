// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Events;

namespace Events.Installations
{
    public class SiteRenamed : IEvent
    {
        public SiteRenamed(Guid siteId, string name)
        {
            SiteId = siteId;
            Name = name;
        }

        public Guid SiteId { get; }

        public string Name { get; }
    }
}