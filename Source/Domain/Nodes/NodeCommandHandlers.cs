/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Nodes
{
    public class NodeCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Node> _aggregateRootRepoForNode;

        public NodeCommandHandlers(IAggregateRootRepositoryFor<Node> aggregateRootRepoForNode)
        {
            _aggregateRootRepoForNode = aggregateRootRepoForNode;
        }

        public void Handle(AddNode command)
        {
            _aggregateRootRepoForNode.Get(command.Id).Add(command.Name);
        }
    }
}