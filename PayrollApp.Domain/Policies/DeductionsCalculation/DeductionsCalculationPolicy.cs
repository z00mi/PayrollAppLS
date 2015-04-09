using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public class DeductionsCalculationPolicy : IDeductionsCalculationPolicy
    {
        internal DeductionsCalculationPolicy()
        {
        }

        public void CalculateDeductions(ref PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
