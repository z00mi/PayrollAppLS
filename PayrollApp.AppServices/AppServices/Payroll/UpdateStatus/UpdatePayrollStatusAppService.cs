using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class UpdatePayrollStatusAppService : IUpdatePayrollStatusAppService
    {
        private readonly IPayrollsRepository _payrollsRepository;

        public UpdatePayrollStatusAppService(IPayrollsRepository payrollsRepository)
        {
            _payrollsRepository = payrollsRepository;
        }

        public void Invoke(UpdatePayrollStatusData args)
        {
            throw new NotImplementedException();
        }
    }
}
