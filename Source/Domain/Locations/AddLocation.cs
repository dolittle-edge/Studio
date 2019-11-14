/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Locations
{
    public class AddLocation : ICommand
    {
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        
    }
}