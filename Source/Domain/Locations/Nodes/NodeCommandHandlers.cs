/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Locations.Nodes
{
    public class NodeCommandHandlers : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<LocatedNode> _aggregateRootRepoForNode;

        public NodeCommandHandlers(IAggregateRootRepositoryFor<LocatedNode> aggregateRootRepoForNode)
        {
            _aggregateRootRepoForNode = aggregateRootRepoForNode;
        }

        public void Handle(AddNodeToLocation command)
        {
            var root = _aggregateRootRepoForNode.Get(command.Id);
            root.Add(command.Name, command.LocationId);
        }
    }
}