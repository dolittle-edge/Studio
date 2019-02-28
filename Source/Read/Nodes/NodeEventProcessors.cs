/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Dolittle.IO.Tenants;
using Dolittle.ReadModels;
using Events.Nodes;

namespace Read.Nodes
{
    public class NodeEventProcessors : ICanProcessEvents
    {

        public NodeEventProcessors(ITenantAwareFileSystem tenantAwareFileSystem)
        {
        }
        
        [EventProcessor("191e2a46-3769-ec50-a2b7-e4bd027ab15f")]
        public void Process(NodeAdded @event)
        { 
            
        }       
    }
}
