using System.Collections.Generic;

namespace Read.Nodes
{
    public interface INodeManager
    {
        IEnumerable<Node> GetAllNodes();
        void Add(Node node);
    }
}