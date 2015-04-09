using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Factories
{
    public class PerformPaymentPolicyFactory : IPerformPaymentPolicyFactory
    {
        public Policies.IPerformPaymentPolicy CreatePerformPaymentPolicy(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }
    }
}
