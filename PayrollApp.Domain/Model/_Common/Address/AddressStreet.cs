using System;

namespace PayrollApp.Domain.Model
{
    public class AddressStreet: StringValueObject
    {
        protected AddressStreet(string street) : base(street)
        {
        }

        public static AddressStreet Create(string street)
        {
            if (street == null) throw new ArgumentNullException("street");

            return new AddressStreet(street);
        }

        public static implicit operator AddressStreet(string street)
        {
            return Create(street);
        }
    }
}
