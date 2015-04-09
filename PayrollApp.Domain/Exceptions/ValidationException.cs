using System;

namespace PayrollApp.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public ValidationException(string caption, string message)
            : base(caption + "|" + message)
        {
        }
    }
}
