using System;

namespace PayrollApp.Domain.Model
{
    public class Address: ValueObject<Address>
    {
        public AddressCity City { get; private set; }
        public AddressStreet Street { get; private set; }
        public AddressNumber Number { get; private set; }


        /// <summary>
        /// Konstruktor dla Repository (via proxy)
        /// </summary>
        protected Address(AddressCity city, AddressStreet street, AddressNumber number)
        {
            City = city;
            Street = street;
            Number = number;
        }


        public static Address Create(AddressCity city, AddressStreet street, AddressNumber number)
        {
            if (city == null) throw new ArgumentNullException("city");
            if (street == null) throw new ArgumentNullException("street");
            if (number == null) throw new ArgumentNullException("number");

            return new Address(city, street, number);
        }

        protected override int GetThisHashCode()
        {
            return City.GetHashCode() ^ Street.GetHashCode() ^ Number.GetHashCode();
        }

        protected override bool ThisEquals(Address other)
        {
            return (other != null) && other.City.Equals(City) && other.Street.Equals(Street) && other.Number.Equals(Number);
        }

        protected override string ThisToString()
        {
            return string.Format("{0} {1} {2}", City, Street, Number);
        }
    }
}
