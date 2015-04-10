using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeePhoneUniqueSpecification : ExpressionSpecification<Employee>
    {
        public EmployeePhoneUniqueSpecification(IEmployeesRepository employeesRepository, EmployeeUid exceptEmployeeUid = null)
            : base(
                u => !u.Phone.HasValue || !employeesRepository.EmployeeExists(u.Phone, exceptEmployeeUid),
                "Isnieje pracownik z takim numerem telefonu"
            )
        {
        }
    }
}
