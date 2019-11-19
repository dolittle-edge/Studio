/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Installations;

namespace Read.Installation
{
    /// <summary>
    /// 
    /// </summary>
    public class InstallationEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Installation> _installations;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insallations"></param>
        public InstallationEventProcessor(IReadModelRepositoryFor<Installation> insallations)
        {
            _installations = insallations;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("eafbe9b6-44f9-40c5-9a7b-f6f196dc44fe")]
        public void Process(InstallationCreated @event, EventMetadata eventMetadata)
        {
            _installations.Insert(new Installation
            {
                Id = @event.InstallationId,
                Name = @event.Name,
                SiteName = @event.SiteName,
            });
        }
    }
}