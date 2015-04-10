using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeHRUniqueSpecyfication : ExpressionSpecification<Employee>
    {
        public EmployeeHRUniqueSpecyfication(IEmployeesRepository employeesRepository, EmployeeUid exceptEmployeeUid = null)
            : base(
                u => !employeesRepository.EmployeeExists(u.HRId, exceptEmployeeUid),
                "Isnieje pracownik z takim HR Id"
            )
        {
        }
    }
}
