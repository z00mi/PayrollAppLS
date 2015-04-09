using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies.PaymentMethod
{
    public class PerformPayByMailPolicy: IPerformPaymentPolicy
    {
        internal PerformPayByMailPolicy()
        {
        }

        public void PerformPayment(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
