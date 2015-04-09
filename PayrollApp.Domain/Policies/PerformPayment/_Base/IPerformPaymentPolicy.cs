using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    /// <summary>
    /// Polityka wyznaczania sposobu wypłacania wynagrodzenia Pracownikowi
    /// </summary>
    public interface IPerformPaymentPolicy
    {
        void PerformPayment(PayCheck payCheck);
    }
}
