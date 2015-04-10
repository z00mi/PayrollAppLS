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
    public class EmployeeValidationSpecificationFactory : IEmployeeValidationSpecificationFactory
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IPayrollsRepository _payrollsRepository;

        public EmployeeValidationSpecificationFactory(
            IEmployeesRepository employeesRepository,
            IPayrollsRepository payrollsRepository)
        {
            _employeesRepository = employeesRepository;
            _payrollsRepository = payrollsRepository;
        }

        public IValidationSpecification<Employee> GetCreatingValidationSpecification()
        {
            return new EmployeeCreatingValidationSpecyfication(_employeesRepository);
        }

        public IValidationSpecification<Employee> GetUpdatingValidationSpecification()
        {
            return new EmployeeUpdatingValidationSpecyfication(_employeesRepository);
        }

        public IValidationSpecification<Employee> GetDeletingValidationSpecification()
        {
            return new EmployeeDeletingValidationSpecyfication(_payrollsRepository);
        }
    }
}
