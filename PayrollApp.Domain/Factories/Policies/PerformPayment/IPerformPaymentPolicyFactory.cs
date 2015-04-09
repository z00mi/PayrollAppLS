using PayrollApp.Domain.Model;
using PayrollApp.Domain.Policies;

namespace PayrollApp.Domain.Factories
{
    /// <summary>
    /// Tworzy politykę wyznaczania sposobu wypłacania wynagrodzenia Pracownikowi
    /// </summary>
    public interface IPerformPaymentPolicyFactory
    {
        IPerformPaymentPolicy CreatePerformPaymentPolicy(PaymentMethod paymentMethod);
    }
}
