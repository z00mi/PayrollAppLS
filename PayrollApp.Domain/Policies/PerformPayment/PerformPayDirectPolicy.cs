using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public class PerformPayDirectPolicy: IPerformPaymentPolicy
    {
        internal PerformPayDirectPolicy()
        {
        }

        public void PerformPayment(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
