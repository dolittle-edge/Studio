using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class AssociatedNode : IReadModel
    {
        public NodeId Id { get; set; }

        public string Name { get; set; }
        public InstallationId InstallationId { get; set; }
    }
}