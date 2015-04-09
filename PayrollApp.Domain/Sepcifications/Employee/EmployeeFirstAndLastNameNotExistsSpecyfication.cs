using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeFirstAndLastNameNotExistsSpecyfication : ExpressionSpecification<Employee>
    {
        public EmployeeFirstAndLastNameNotExistsSpecyfication(IEmployeesRepository employeesRepository, EmployeeUid exceptEmployeeUid = null)
            : base(
                u => !employeesRepository.EmployeeExists(u.FirstName, u.LastName, exceptEmployeeUid),
                "Isnieje pracownik z takim imieniem i nazwiskiem"
            )
        {
        }
    }
}
