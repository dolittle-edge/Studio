/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts.Installations
{
    public class SiteId : ConceptAs<Guid>
    {
        public static implicit operator SiteId(Guid siteId) => new SiteId { Value = siteId };

        public static implicit operator EventSourceId(SiteId siteId) => new EventSourceId { Value = siteId.Value };
    }
}