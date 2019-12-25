// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Concepts.Installations;
using Dolittle.Commands;

namespace Domain.Installations
{
    public class CreateInstallation : ICommand
    {
        public SiteName SiteName { get; set; }

        public InstallationName Name { get; set; }
    }
}