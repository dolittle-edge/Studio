/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Concepts.Installations
{
    public class SiteId : ConceptAs<Guid>
    {
        public static implicit operator SiteId(Guid siteId) => new SiteId { Value = siteId };
    }
}