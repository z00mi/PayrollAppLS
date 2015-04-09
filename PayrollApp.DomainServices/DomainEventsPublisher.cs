using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Services;
using PayrollApp.Infrastructure.MessageBus;

namespace PayrollApp.Infrastructure.DomainServices
{
    public class DomainEventsPublisher : IDomainEventsPublisher
    {
        private readonly IMessagePublisher _messagePublisher;

        public DomainEventsPublisher(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public void Publish<T>(T domainEvent) where T : Domain.Events.IDomainEvent
        {
            _messagePublisher.AddToSendBuffer(domainEvent);
        }
    }
}
