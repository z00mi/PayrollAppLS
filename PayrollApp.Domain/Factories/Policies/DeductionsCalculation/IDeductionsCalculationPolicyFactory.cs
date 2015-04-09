using PayrollApp.Domain.Model;
using PayrollApp.Domain.Policies;

namespace PayrollApp.Domain.Factories
{
    /// <summary>
    /// Tworzy politykę wyliczania składek odprowadzanych przez członka na rzecz Organizacji
    /// </summary>
    public interface IDeductionsCalculationPolicyFactory
    {
        IDeductionsCalculationPolicy CreateDeductionsCalculationPolicy(
            Affiliation affiliation, Date payPeriodStartDate, Date payPeriodEndDate);
    }
}
