/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands;

namespace Domain.Installations
{
    public class RegisterSite : ICommand
    {
        public string Name { get; set; }
    }
}