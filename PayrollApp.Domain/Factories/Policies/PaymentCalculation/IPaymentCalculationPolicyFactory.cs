using PayrollApp.Domain.Model;
using PayrollApp.Domain.Policies;

namespace PayrollApp.Domain.Factories
{
    /// <summary>
    /// Twozry politykę obliczania wypłaty Pracownika
    /// </summary>
    public interface IPaymentCalculationPolicyFactory
    {
        IPaymentCalculationPolicy CreatePaymentCalculationPolicy(PaymentClassification paymentClassification,
            Date payPeriodStartDate, Date payPeriodEndDate);
    }
}
