using PayrollApp.Domain.Events;

namespace PayrollApp.Domain.Services
{
    public interface IDomainEventsPublisher
    {
        void Publish<T>(T domainEvent) where T : IDomainEvent;
    }
}
