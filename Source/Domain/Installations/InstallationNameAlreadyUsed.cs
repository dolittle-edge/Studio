/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Domain.Installations
{
    public class InstallationNameAlreadyUsed : Exception
    {
        public InstallationNameAlreadyUsed(string name) : base($"The installation '{name}' is already created") {}
    }
}