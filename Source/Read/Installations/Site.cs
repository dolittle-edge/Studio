using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class Site : IReadModel
    {
        public SiteId Id { get; set; }

        public string Name { get; set; }
    }
}