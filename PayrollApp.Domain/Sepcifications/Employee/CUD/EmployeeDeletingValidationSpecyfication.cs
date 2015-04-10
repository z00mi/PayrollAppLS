using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeDeletingValidationSpecyfication : ValidationSpecification<Employee>
    {
        private readonly IPayrollsRepository _payrollsRepository;

        public EmployeeDeletingValidationSpecyfication(IPayrollsRepository payrollsRepository)
        {
            _payrollsRepository = payrollsRepository;
        }

        public override bool IsSatisfiedBy(Employee o, ref string failedMessages)
        {
            var hasNotPayroll = new EmployeeHasNotPayrollSpecification(_payrollsRepository);

            return
                hasNotPayroll
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
