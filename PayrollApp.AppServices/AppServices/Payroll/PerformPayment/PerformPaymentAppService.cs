using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class PerformPaymentAppService : IPerformPaymentAppService
    {
        private readonly IPayrollsRepository _payrollsRepository;

        public PerformPaymentAppService(IPayrollsRepository payrollsRepository)
        {
            _payrollsRepository = payrollsRepository;
        }

        public void Invoke(Guid payrollUid)
        {
            var payroll = _payrollsRepository.Get(payrollUid);

            //_payrollService.PerformPayment();
        }
    }
}
