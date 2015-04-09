using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies.PaymentMethod
{
    public class PerformPayHoldPolicy: IPerformPaymentPolicy
    {
        internal PerformPayHoldPolicy()
        {
        }

        public void PerformPayment(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
