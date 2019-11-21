/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands;
using Concepts.Installations;

namespace Domain.Installations
{
    public class RenameNode : ICommand
    {
        public NodeName OldName { get; set; }
        public NodeName NewName { get; set; }
    }
}