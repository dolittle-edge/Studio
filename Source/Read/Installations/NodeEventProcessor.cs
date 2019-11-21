using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Installations;

namespace Read.Installations
{
    public class NodeEventProcessors : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<UnassociatedNode> _repository;

        public NodeEventProcessors(IReadModelRepositoryFor<UnassociatedNode> repository)
        {
            _repository = repository;
        }

        [EventProcessor("c73b4930-e2fd-411c-94b8-f394789b9abc")]
        public void Process(NodeRegistered @event)
        {
            _repository.Insert(new UnassociatedNode { Id = @event.NodeId, Name = @event.Name });
        }

        [EventProcessor("d8c62032-00be-439c-bd9c-aed304c6a234")]
        public void Process(NodeRenamed @event)
        {
            var node = _repository.GetById(@event.NodeId);
            node.Name = @event.Name;
            _repository.Update(node);
        }
    }
}