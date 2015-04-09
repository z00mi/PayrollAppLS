using System;

namespace PayrollApp.Domain.Model
{
    public class AddressNumber: StringValueObject
    {
        protected AddressNumber(string number) : base(number)
        {
        }

        public static AddressNumber Create(string number)
        {
            if (number == null) throw new ArgumentNullException("number");

            return new AddressNumber(number);
        }

        public static implicit operator AddressNumber(string number)
        {
            return Create(number);
        }
    }
}
