/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Installations
{
    public class InstallationOnSite : Value<InstallationOnSite>
    {
        public SiteId SiteId { get; set; }
        public InstallationName InstallationName { get; set; }
    }
}