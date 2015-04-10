using System;
using PayrollApp.Domain.Events;
using PayrollApp.Domain.Services;

namespace PayrollApp.Domain.Model
{
    public abstract class AggregateRoot
    {
        private static IDomainEventsPublisher _eventsPublisher;

        public static void InitEventsPublisher(IDomainEventsPublisher eventsPublisher)
        {
            if(_eventsPublisher != null)
                throw new InvalidOperationException("EventsPublisher already initialized");

            _eventsPublisher = eventsPublisher;
        }

        /// <summary>
        /// Publikowanie DomainEvent przez agregat
        /// </summary>
        protected static void PublishEvent(IDomainEvent @event)
        {
            _eventsPublisher.Publish(@event);
        }
    }

    /// <summary>
    /// Klasa bazowa agregatów
    /// </summary>
    /// <typeparam name="TUid">Typ Uid agregatu</typeparam>
    public abstract class AggregateRoot<TUid> : AggregateRoot
    {
        public TUid Uid { get; private set; }

        protected AggregateRoot(TUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            Uid = uid;
        }

        #region comparision by Uid

        public override bool Equals(object obj)
        {
            return Uid.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Uid.GetHashCode();
        }

        public override string ToString()
        {
            return Uid.ToString();
        }

        #endregion
    }

}
