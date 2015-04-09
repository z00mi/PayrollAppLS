using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Services;

namespace PayrollApp.AppServices
{
    public class GeneratePayrollAppService : IGeneratePayrollAppService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IPayrollService _payrollService;
        private readonly IPayrollsRepository _payrollRepository;
        

        public GeneratePayrollAppService(
            IEmployeesRepository employeesRepository,
            IPayrollService payrollService,
            IPayrollsRepository payrollRepository)
        {
            _employeesRepository = employeesRepository;
            _payrollService = payrollService;
            _payrollRepository = payrollRepository;
        }

        public Guid Invoke(DateTime forDate)
        {
            var employees = _employeesRepository.GetAll();
            var payroll = _payrollService.GeneratePayroll(employees, forDate);

            _payrollRepository.Insert(payroll);
            _payrollRepository.Save();

            return payroll.Uid;
        }
    }
}
