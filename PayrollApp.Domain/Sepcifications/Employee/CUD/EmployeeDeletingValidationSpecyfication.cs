using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeDeletingValidationSpecyfication : ValidationSpecification<Employee>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeeDeletingValidationSpecyfication(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public override bool IsSatisfiedBy(Employee o, ref string failedMessages)
        {
            return true; //TODO warunki (nie mozna usunac jesli jest w Payroll???)
        }
    }
}
