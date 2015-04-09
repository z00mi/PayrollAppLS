using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Factories
{
    public class DeductionsCalculationPolicyFactory : IDeductionsCalculationPolicyFactory
    {
        public Policies.IDeductionsCalculationPolicy CreateDeductionsCalculationPolicy(
            Affiliation affiliation, Date payPeriodStartDate, Date payPeriodEndDate)
        {
            throw new NotImplementedException();
        }
    }
}
