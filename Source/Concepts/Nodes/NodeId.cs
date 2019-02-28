using Dolittle.Concepts;
using System;

namespace Concepts.Nodes
{
    public class NodeId : ConceptAs<Guid>
    {
        public static implicit operator NodeId(Guid value)
        {
            return new NodeId {Value = value};
        }
    }
}
