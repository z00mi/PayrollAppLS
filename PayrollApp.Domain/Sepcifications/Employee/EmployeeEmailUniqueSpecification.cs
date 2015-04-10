using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeEmailUniqueSpecification : ExpressionSpecification<Employee>
    {
        public EmployeeEmailUniqueSpecification(IEmployeesRepository employeesRepository, EmployeeUid exceptEmployeeUid = null)
            : base(
                u => !u.Email.HasValue || !employeesRepository.EmployeeExists(u.Email, exceptEmployeeUid),
                "Isnieje pracownik z takim adresem email"
            )
        {
        }
    }
}
