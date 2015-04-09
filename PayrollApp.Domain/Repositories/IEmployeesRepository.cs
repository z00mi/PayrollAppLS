using System.Collections.Generic;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Repositories
{
    public interface IEmployeesRepository : IRepository<Employee, EmployeeUid>
    {
        bool EmployeeExists(NullableValObj<EmailAddress> employeeEmail, EmployeeUid exceptEmployeeUid);
        bool EmployeeExists(EmployeeFirstName employeeFirstName, EmployeeLastName employeeLastName, EmployeeUid exceptEmployeeUid);
    }
}
