using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Policies;

namespace PayrollApp.Domain.Factories
{
    public class PaymentCalculationPolicyFactory : IPaymentCalculationPolicyFactory
    {

        public IPaymentCalculationPolicy CreatePaymentCalculationPolicy(
            PaymentClassification paymentClassification, Date payPeriodStartDate, Date payPeriodEndDate)
        {
            throw new NotImplementedException();
        }
    }
}
