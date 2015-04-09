using PayrollApp.Domain.Model;
using PayrollApp.Domain.Policies;

namespace PayrollApp.Domain.Factories
{
    /// <summary>
    /// Tworzy politykę wyznaczania Harmonogramu wypłat Pracownika
    /// </summary>
    public interface IPaymentScheduleCalculationPolicyFactory
    {
        IPaymentScheduleCalculationPolicy CreatePaymentSchedulePolicy(EmployeePaymentScheduleType employeePaymentScheduleType);
    }
}
