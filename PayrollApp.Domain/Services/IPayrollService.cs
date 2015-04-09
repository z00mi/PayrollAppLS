using System.Collections.Generic;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Services
{
    public interface IPayrollService
    {
        Payroll GeneratePayroll(IEnumerable<Employee> employees, Date forDate);
    }
}
