using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public class SalariedPayCalculationPolicy: PaymentCalculationPolicy
    {
        private readonly SalariedClassification _salariedClassification;

        public SalariedPayCalculationPolicy(SalariedClassification salariedClassification, Date payPeriodStartDate, Date payPeriodEndDate)
            : base(payPeriodStartDate, payPeriodEndDate)
        {
            _salariedClassification = salariedClassification;
        }

        public override void CalculatePay(ref PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
