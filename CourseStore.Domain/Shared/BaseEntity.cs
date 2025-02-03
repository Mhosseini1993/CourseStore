using MediatR;

namespace CourseStore.Domain.Shared
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreationDate { get; }

        public BaseEntity()
        {
            CreationDate= DateTime.Now;
        }
    }
    public class BaseDomainEvent : INotification
    {
        public DateTime CreationDate { get; protected set; }
        public BaseDomainEvent()
        {
            CreationDate = DateTime.Now;
        }
    }
    public class BaseAggregate : BaseEntity
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(BaseDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }
        public void RemoveDomainEvent(BaseDomainEvent @event)
        {
            _domainEvents.Remove(@event);
        }
    }
}
