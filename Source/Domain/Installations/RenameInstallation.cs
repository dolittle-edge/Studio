/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands;
using Concepts.Installations;

namespace Domain.Installations
{
    public class RenameInstallation : ICommand
    {
        public SiteId SiteId { get; set; }
        public InstallationName OldName { get; set; }
        public InstallationName NewName { get; set; }
    }
}