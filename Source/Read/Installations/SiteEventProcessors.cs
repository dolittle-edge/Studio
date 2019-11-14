using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Installations;

namespace Read.Installations
{
    public class SiteEventProcessors : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Site> _repository;

        public SiteEventProcessors(IReadModelRepositoryFor<Site> repository)
        {
            _repository = repository;
        }

        [EventProcessor("ebb218fc-3b80-4736-bb8a-72cfeff75202")]
        public void Process(SiteRegistered @event)
        {
            _repository.Insert(new Site { Id = @event.SiteId, Name = @event.Name });
        }

        [EventProcessor("fb1b7170-1e1b-4822-a7d6-cbf594cb67ab")]
        public void Process(SiteRenamed @event)
        {
            var site = _repository.GetById(@event.SiteId);
            site.Name = @event.Name;
            _repository.Update(site);
        }
    }
}