using System.Collections.Generic;
using Concepts.Locations;

namespace Read.Nodes
{
    public interface INodeManager
    {
        IEnumerable<Node> GetAllNodesFor(LocationId locationId);
        void Add(LocationId locationId, Node node);
    }
}