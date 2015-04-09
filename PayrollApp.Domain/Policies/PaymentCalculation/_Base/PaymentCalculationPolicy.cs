using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public abstract class PaymentCalculationPolicy : IPaymentCalculationPolicy
    {
        protected Date PayPeriodStartDate { get; private set; }
        protected Date PayPeriodEndDate { get; private set; }

        protected PaymentCalculationPolicy(Date payPeriodStartDate, Date payPeriodEndDate)
        {
            PayPeriodStartDate = payPeriodStartDate;
            PayPeriodEndDate = payPeriodEndDate;
        }

        public abstract void CalculatePay(ref PayCheck payCheck);
    }
}
