using System;

namespace PayrollApp.Domain.Model
{
    public class Money : DecimalValueObject
    {

        protected Money(decimal amount): base(amount)
        {
        }

        public static Money Create(decimal amount)
        {
            return new Money(amount);
        }

        public static Money operator +(Money m1, Money m2)
        {
            return Create((decimal)m1 + (decimal)m2);
        }

        public static implicit operator Money(decimal amount)
        {
            return Create(amount);
        }
    }
}
