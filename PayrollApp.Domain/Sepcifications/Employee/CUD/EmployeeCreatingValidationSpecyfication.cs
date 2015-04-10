using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeCreatingValidationSpecyfication : ValidationSpecification<Employee>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeeCreatingValidationSpecyfication(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public override bool IsSatisfiedBy(Employee o, ref string failedMessages)
        {
            var hrUnique = new EmployeeHRUniqueSpecyfication(_employeesRepository);
            var emailUnique = new EmployeeEmailUniqueSpecification(_employeesRepository);
            var phoneUnique = new EmployeePhoneUniqueSpecification(_employeesRepository);
            var addressesUnique = new EmployeeAddressesUniqueSpecyfication();

            return
                hrUnique
                .And(emailUnique)
                .And(phoneUnique)
                .And(addressesUnique)
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
