using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.AppServices
{
    public class AddEmployeeAppService : EmployeeAppServiceBase, IAddEmployeeAppService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeeValidationSpecificationFactory _validationSpecificationFactory;

        public AddEmployeeAppService(
            IEmployeesRepository employeesRepository,
            IEmployeeValidationSpecificationFactory validationSpecificationFactory)
        {
            _employeesRepository = employeesRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public Guid Invoke(AddEmployeeData args)
        {
            var newEmployee = Employee.Create(
                args.FirstName,
                args.LastName,
                args.Email != null ? EmailAddress.Create(args.Email): null,
                args.Phone != null ? PhoneNumber.Create(args.Phone): null,
                args.Address.Select(x => Address.Create(x.City, x.Street, x.Number)),
                GetPaymentScheduleType(args.PaymentScheduleType),
                GetPaymentClassification(args.PaymentClassification),
                GetPaymentMethod(args.PaymentMethod),
                _validationSpecificationFactory.GetCreatingValidationSpecification());

            _employeesRepository.Insert(newEmployee);
            _employeesRepository.Save();

            return newEmployee.Uid;
        }
    }
}
