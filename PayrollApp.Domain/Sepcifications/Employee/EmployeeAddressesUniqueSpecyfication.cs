using System.Linq;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeAddressesUniqueSpecyfication : ExpressionSpecification<Employee>
    {
        public EmployeeAddressesUniqueSpecyfication()
            : base(AddressesAreUnique, "Adresy nie są unikalne")
        {
        }

        internal static bool AddressesAreUnique(Employee employee)
        {
            var addresses = employee.Addresses;
            var distinctCount = addresses.Distinct().ToList().Count();
            return addresses.Count == distinctCount;
        }
    }
}
