using System;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Sposób płatności wynagrodzenia Pracownika - czek wysyłany kurierem na adres podany przez Pracownika
    /// </summary>
    public class MailMethod: PaymentMethod
    {
        public Address PaycheckAddress { get; private set; }
        
        protected MailMethod(Address paycheckAddress)
        {
            PaycheckAddress = paycheckAddress;
        }

        public static MailMethod Create(Address paycheckAddress)
        {
            if (paycheckAddress == null) throw new ArgumentNullException("paycheckAddress");

            return new MailMethod(paycheckAddress);
        }
    }
}
