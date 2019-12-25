// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Concepts.Installations;
using Dolittle.Commands;

namespace Domain.Installations
{
    public class RenameInstallation : ICommand
    {
        public SiteName SiteName { get; set; }

        public InstallationName OldName { get; set; }

        public InstallationName NewName { get; set; }
    }
}