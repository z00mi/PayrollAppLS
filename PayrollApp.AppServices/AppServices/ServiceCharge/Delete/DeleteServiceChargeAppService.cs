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
    public class DeleteServiceChargeAppService : IDeleteServiceChargeAppService
    {
        private readonly IServiceChargesRepository _serviceChargesRepository;
        private readonly IServiceChargeValidationSpecificationFactory _validationSpecificationFactory;

        public DeleteServiceChargeAppService(
            IServiceChargesRepository serviceChargesRepository,
            IServiceChargeValidationSpecificationFactory validationSpecificationFactory)
        {
            _serviceChargesRepository = serviceChargesRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(Guid uid)
        {
            var serviceCharge = _serviceChargesRepository.Get(uid);

            serviceCharge.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _serviceChargesRepository.Delete(serviceCharge);
            _serviceChargesRepository.Save();
        }
    }
}
