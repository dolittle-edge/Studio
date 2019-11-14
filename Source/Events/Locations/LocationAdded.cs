/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Locations
{
    public class LocationAdded : IEvent
    {
        public LocationAdded(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}