using System.Collections.Generic;
using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class NodeStatus : IReadModel
    {
        public NodeId Id { get; set; }

        public InstallationId InstallationId { get; set; }

        public Dictionary<string, float>   Metrics { get; set; }
    }
}