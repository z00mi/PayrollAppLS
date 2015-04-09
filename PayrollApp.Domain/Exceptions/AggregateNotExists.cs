using System;

namespace PayrollApp.Domain.Exceptions
{
    public class AggregateNotExistsException : DomainException
    {
        public AggregateNotExistsException() : base("")
        {
        }

        public AggregateNotExistsException(string message)
            : base(message)
        {
        }
    }
}
