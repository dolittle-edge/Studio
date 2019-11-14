/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands;

namespace Domain.Installations
{
    public class RenameSite : ICommand
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}