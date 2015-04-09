using System;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Sposób płatności wynagrodzenia Pracownika - przelew do banku
    /// </summary>
    public class DirectMethod: PaymentMethod
    {
        public DirectMethodBank Bank { get; private set; }
        public DirectMethodAccount Account { get; private set; }

        protected DirectMethod(DirectMethodBank bank, DirectMethodAccount account)
        {
            Bank = bank;
            Account = account;
        }

        public static DirectMethod Create(DirectMethodBank bank, DirectMethodAccount account)
        {
            if (bank == null) throw new ArgumentNullException("bank");
            if (account == null) throw new ArgumentNullException("account");

            return new DirectMethod(bank, account);
        }
    }
}
