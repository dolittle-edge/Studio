/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Nodes;
using System.Linq;

namespace Rules.Nodes
{
    public class NameMustBeUnique : IRuleImplementationFor<Domain.Nodes.NameMustBeUnique>
    {
        readonly IReadModelRepositoryFor<Node> _nodes;
        public NameMustBeUnique(IReadModelRepositoryFor<Node> nodes) => _nodes = nodes;
        public Domain.Nodes.NameMustBeUnique Rule => (name) => !_nodes.Query.Any(_ => _.Name == name);
    }
}