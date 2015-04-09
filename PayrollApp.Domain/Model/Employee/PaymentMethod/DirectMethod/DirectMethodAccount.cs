using System;

namespace PayrollApp.Domain.Model
{
    public class DirectMethodAccount : StringValueObject
    {
        protected DirectMethodAccount(string accountNumber): base(accountNumber)
        {
        }

        public static DirectMethodAccount Create(string accountNumber)
        {
            if (accountNumber == null) throw new ArgumentNullException("accountNumber");
            //TODO walidacja

            return new DirectMethodAccount(accountNumber);
        }

        public static implicit operator DirectMethodAccount(string accountNumber)
        {
            return Create(accountNumber);
        }
    }
}
