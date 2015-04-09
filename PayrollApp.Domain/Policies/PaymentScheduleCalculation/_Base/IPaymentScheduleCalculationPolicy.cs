using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Policies
{
    /// <summary>
    /// Polityka wyznaczania Harmonogramu wypłat Pracownika
    /// </summary>
    public interface IPaymentScheduleCalculationPolicy
    {
        bool IsPayDate(Date date);
        Date GetPayPeriodStartDate(Date payDate);
    }
}
