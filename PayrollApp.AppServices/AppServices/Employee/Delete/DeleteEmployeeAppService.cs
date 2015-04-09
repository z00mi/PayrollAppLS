using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class DeleteEmployeeAppService : IDeleteEmployeeAppService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeeValidationSpecificationFactory _validationSpecificationFactory;

        public DeleteEmployeeAppService(
            IEmployeesRepository employeesRepository,
            IEmployeeValidationSpecificationFactory validationSpecificationFactory)
        {
            _employeesRepository = employeesRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(Guid uid)
        {
            var employee = _employeesRepository.Get(uid);

            employee.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _employeesRepository.Delete(employee);
            _employeesRepository.Save();
        }
    }
}
