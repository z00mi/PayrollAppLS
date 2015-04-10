using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeUpdatingValidationSpecyfication : ValidationSpecification<Employee>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeeUpdatingValidationSpecyfication(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public override bool IsSatisfiedBy(Employee o, ref string failedMessages)
        {
            var hrUnique = new EmployeeHRUniqueSpecyfication(_employeesRepository, o.Uid);
            var emailUnique = new EmployeeEmailUniqueSpecification(_employeesRepository, o.Uid);
            var phoneUnique = new EmployeePhoneUniqueSpecification(_employeesRepository, o.Uid);
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
