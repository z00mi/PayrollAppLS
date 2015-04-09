using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    public class WeeklySchedulePolicy: IPaymentScheduleCalculationPolicy
    {
        public bool IsPayDate(Date date)
        {
            throw new NotImplementedException();
        }

        public Date GetPayPeriodStartDate(Date payDate)
        {
            throw new NotImplementedException();
        }
    }
}
