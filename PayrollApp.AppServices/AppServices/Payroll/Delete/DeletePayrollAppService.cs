using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class DeletePayrollAppService : IDeletePayrollAppService
    {
        private readonly IPayrollsRepository _payrollsRepository;
        private readonly IPayrollValidationSpecificationFactory _validationSpecificationFactory;

        public DeletePayrollAppService(
            IPayrollsRepository payrollsRepository,
            IPayrollValidationSpecificationFactory validationSpecificationFactory)
        {
            _payrollsRepository = payrollsRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(Guid uid)
        {
            var payroll = _payrollsRepository.Get(uid);

            payroll.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _payrollsRepository.Delete(payroll);
            _payrollsRepository.Save();
        }
    }
}
