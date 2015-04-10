using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeHasNotPayrollSpecification : ExpressionSpecification<Employee>
    {
        public EmployeeHasNotPayrollSpecification(IPayrollsRepository payrollsRepository)
            : base(
                u => !payrollsRepository.PayrollExists(u.Uid),
                "Isnieje lista płac dla tego pracownika"
            )
        {
        }
    }
}
