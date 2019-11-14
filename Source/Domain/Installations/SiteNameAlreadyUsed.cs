/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Domain.Installations
{
    public class SiteNameAlreadyUsed : Exception
    {
        public SiteNameAlreadyUsed(string name) : base($"The '{name}' is already registerd as a site") {}
    }
}