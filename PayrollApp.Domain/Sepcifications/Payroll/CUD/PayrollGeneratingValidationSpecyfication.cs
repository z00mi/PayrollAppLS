using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class PayrollGeneratingValidationSpecyfication : ValidationSpecification<Payroll>
    {
        private readonly IPayrollsRepository _payrollsRepository;

        public PayrollGeneratingValidationSpecyfication(IPayrollsRepository payrollsRepository)
        {
            _payrollsRepository = payrollsRepository;
        }

        public override bool IsSatisfiedBy(Payroll o, ref string failedMessages)
        {
            //return 
            //    _emailNotExists
            //    .And(_employeeFirstAndLastNameNotExists)
            //    .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
