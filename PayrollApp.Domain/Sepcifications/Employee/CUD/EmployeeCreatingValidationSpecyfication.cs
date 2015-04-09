using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeCreatingValidationSpecyfication : ValidationSpecification<Employee>
    {
        private readonly EmployeeEmailNotExistsSpecification _emailNotExists;
        private readonly EmployeeFirstAndLastNameNotExistsSpecyfication _employeeFirstAndLastNameNotExists;

        public EmployeeCreatingValidationSpecyfication(IEmployeesRepository employeesRepository)
        {
            _emailNotExists = new EmployeeEmailNotExistsSpecification(employeesRepository);
            _employeeFirstAndLastNameNotExists = new EmployeeFirstAndLastNameNotExistsSpecyfication(employeesRepository);
        }

        public override bool IsSatisfiedBy(Employee o, ref string failedMessages)
        {
            return 
                _emailNotExists
                .And(_employeeFirstAndLastNameNotExists)
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
