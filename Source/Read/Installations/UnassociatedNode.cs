using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class UnassociatedNode : IReadModel
    {
        public NodeId Id { get; set; }

        public string Name { get; set; }
    }
}