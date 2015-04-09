using System;

namespace PayrollApp.Domain.Model
{
    public class DirectMethodBank : StringValueObject
    {
        protected DirectMethodBank(string bank) : base(bank)
        {
        }

        public static DirectMethodBank Create(string bank)
        {
            if (bank == null) throw new ArgumentNullException("bank");
            //TODO walidacja

            return new DirectMethodBank(bank);
        }

        public static implicit operator DirectMethodBank(string bank)
        {
            return Create(bank);
        }
    }
}
