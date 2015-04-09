using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public class HourlyPayCalculationPolicy: PaymentCalculationPolicy
    {
        private readonly HourlyClassification _hourlyClassification;

        public HourlyPayCalculationPolicy(HourlyClassification hourlyClassification, Date payPeriodStartDate, Date payPeriodEndDate)
            : base(payPeriodStartDate, payPeriodEndDate)
        {
            _hourlyClassification = hourlyClassification;
        }

        public override void CalculatePay(ref PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}
