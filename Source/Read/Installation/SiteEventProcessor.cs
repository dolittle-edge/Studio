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
    public class SiteEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Site> _sites;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sites"></param>
        public SiteEventProcessor(IReadModelRepositoryFor<Site> sites)
        {
            _sites = sites;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("b38f5e6b-10ec-4f50-bfaf-344c2201cb1f")]
        public void Process(SiteRegistered @event, EventMetadata eventMetadata)
        {
            _sites.Insert(new Site
            {
                Id = @event.SiteId,
                Name = @event.Name,
            });
        }

        /// <summary>
        /// 
        /// </summary>
        [EventProcessor("b8c9c64b-0795-46ac-98b3-428afa510486")]
        public void Process(SiteRenamed @event, EventMetadata eventMetadata)
        {
            
        }
    }
}