using Concepts.Locations;
using Dolittle.ReadModels;

namespace Read.Locations
{
    public class Location : IReadModel
    {
        public LocationId Id {get; set;}
        
        public LocationName Name {get; set;}
    }
}
