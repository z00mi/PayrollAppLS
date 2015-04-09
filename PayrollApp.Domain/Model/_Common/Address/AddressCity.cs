using System;

namespace PayrollApp.Domain.Model
{
    public class AddressCity: StringValueObject
    {
        protected AddressCity(string city) : base(city)
        {
        }

        public static AddressCity Create(string city)
        {
            if (city == null) throw new ArgumentNullException("city");

            return new AddressCity(city);
        }

        public static implicit operator AddressCity(string city)
        {
            return Create(city);
        }
    }
}
