using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public class CommisionedPayCalculationPolicy : PaymentCalculationPolicy
    {
        private readonly CommisionedClassification _commisionedClassification;

        public CommisionedPayCalculationPolicy(CommisionedClassification commisionedClassification, Date payPeriodStartDate, Date payPeriodEndDate) 
            : base(payPeriodStartDate, payPeriodEndDate)
        {
            _commisionedClassification = commisionedClassification;
        }

        public override void CalculatePay(ref PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
