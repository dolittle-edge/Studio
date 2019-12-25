// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Concepts;

namespace Concepts.Installations
{
    public class InstallationOnSite : Value<InstallationOnSite>
    {
        public SiteId SiteId { get; set; }

        public InstallationName InstallationName { get; set; }
    }
}