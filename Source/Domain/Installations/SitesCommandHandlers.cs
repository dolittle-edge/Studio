/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Execution;

namespace Domain.Installations
{
    public class SitesCommandHandlers : ICanHandleCommands
    {
        readonly IExecutionContextManager _executionContextManager;
        readonly IAggregateOf<Sites> _sites;

        public SitesCommandHandlers(
            IAggregateOf<Sites> sites,
            IExecutionContextManager executionContextManager)
        {
            _executionContextManager = executionContextManager;
            _sites = sites;
        }

        public void Handle(RegisterSite register)
        {
            if( _sites.Perform(_executionContextManager.Current.Tenant.Value, _ => _.Register(Guid.NewGuid(), register.Name)) )
            {
                // Yippi
            }
        }

        public void Handle(RenameSite rename)
        {
            if( _sites.Perform(_executionContextManager.Current.Tenant.Value, _ => _.Rename(rename.OldName, rename.NewName)) )
            {
                // Yippi
            }
        }
    }
}