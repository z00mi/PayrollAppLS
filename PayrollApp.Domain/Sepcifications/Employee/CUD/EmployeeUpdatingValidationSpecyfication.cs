using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeUpdatingValidationSpecyfication : ValidationSpecification<Employee>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly EmployeeAddressesAreUniqueSpecyfication _addressesAreUnique;

        public EmployeeUpdatingValidationSpecyfication(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
            _addressesAreUnique = new EmployeeAddressesAreUniqueSpecyfication();
        }

        public override bool IsSatisfiedBy(Employee o, ref string failedMessages)
        {
            var emailNotExists = new EmployeeEmailNotExistsSpecification(_employeesRepository, o.Uid);
            var employeeFirstAndLastNameNotExists = new EmployeeFirstAndLastNameNotExistsSpecyfication(_employeesRepository, o.Uid);

            return 
                emailNotExists
                .And(employeeFirstAndLastNameNotExists)
                .And(_addressesAreUnique).
                IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
