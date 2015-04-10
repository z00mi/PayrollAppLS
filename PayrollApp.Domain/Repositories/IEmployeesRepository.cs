using System.Collections.Generic;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Repositories
{
    public interface IEmployeesRepository : IRepository<Employee, EmployeeUid>
    {
        bool EmployeeExists(EmployeeHRId employeeHRId, EmployeeUid exceptEmployeeUid);
        bool EmployeeExists(NullableValObj<EmailAddress> employeeEmail, EmployeeUid exceptEmployeeUid);
        bool EmployeeExists(NullableValObj<PhoneNumber> employeePhone, EmployeeUid exceptEmployeeUid);
    }
}
