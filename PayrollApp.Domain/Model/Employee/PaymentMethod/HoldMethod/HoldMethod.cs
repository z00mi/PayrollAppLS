namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Sposób płatności wynagrodzenia Pracownika - odbiór osobisty gotówki w kasie firmy
    /// </summary>
    public class HoldMethod: PaymentMethod
    {
        protected HoldMethod()
        {
        }

        public static HoldMethod Create()
        {
            return new HoldMethod();
        }
    }
}
