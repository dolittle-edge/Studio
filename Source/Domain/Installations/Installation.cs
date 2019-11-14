/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Domain;
using Dolittle.Runtime.Events;

namespace Domain.Installations
{
    public class Installation : AggregateRoot
    {
        public Installation(EventSourceId id) : base(id) { }
    }
}