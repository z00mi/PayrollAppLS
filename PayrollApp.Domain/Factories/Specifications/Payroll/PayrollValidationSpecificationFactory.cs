using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Factories
{
    public class PayrollValidationSpecificationFactory : IPayrollValidationSpecificationFactory
    {
        private readonly IPayrollsRepository _payrollsRepository;

        public PayrollValidationSpecificationFactory(IPayrollsRepository payrollsRepository)
        {
            _payrollsRepository = payrollsRepository;
        }

        public IValidationSpecification<Payroll> GetGeneratingValidationSpecification()
        {
            return new PayrollGeneratingValidationSpecyfication(_payrollsRepository);
        }

        public IValidationSpecification<Payroll> GetDeletingValidationSpecification()
        {
            return new PayrollDeletingValidationSpecyfication(_payrollsRepository);
        }
    }
}
