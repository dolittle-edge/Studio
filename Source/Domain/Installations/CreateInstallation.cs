/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.Installations;
using Dolittle.Commands;

namespace Domain.Installations
{
    public class CreateInstallation : ICommand
    {
        public string Name { get; set; }

        public SiteName SiteName { get; set; }
    }
}