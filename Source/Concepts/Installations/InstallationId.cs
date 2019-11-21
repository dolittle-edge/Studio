/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Concepts.Installations
{
    public class InstallationId : ConceptAs<Guid>
    {
        public static implicit operator InstallationId(Guid siteId) => new InstallationId { Value = siteId };
    }
}