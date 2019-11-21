/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Installations;

namespace Read.Installations
{
    /// <summary>
    /// 
    /// </summary>
    public class InstallationEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Installation> _installations;

        public InstallationEventProcessor(IReadModelRepositoryFor<Installation> insallations)
        {
            _installations = insallations;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("eafbe9b6-44f9-40c5-9a7b-f6f196dc44fe")]
        public void Process(InstallationStarted @event, EventMetadata eventMetadata)
        {
            _installations.Insert(new Installation
            {
                Id = @event.InstallationId,
                Name = @event.Name,
                SiteId = eventMetadata.EventSourceId.Value
            });
        }

        [EventProcessor("c5e7ffca-aaab-4ae7-9ad9-a1a87247f8d7")]
        public void Process(InstallationRenamed @event)
        {
            var installation = _installations.GetById(@event.InstallationId);
            installation.Name = @event.Name;
            _installations.Update(installation);
        }
    }
}