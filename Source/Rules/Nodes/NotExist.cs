/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Nodes;

namespace Rules.Nodes
{
    public class NotExist : IRuleImplementationFor<Domain.Nodes.NotExist>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;
        public NotExist(IReadModelRepositoryFor<Node> nodes) => _nodes = nodes;
        public Domain.Nodes.NotExist Rule => (id) => _nodes.GetById(id) == null;
    }
}