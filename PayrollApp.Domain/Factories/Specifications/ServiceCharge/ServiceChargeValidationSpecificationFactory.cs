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
    public class ServiceChargeValidationSpecificationFactory : IServiceChargeValidationSpecificationFactory
    {
        private readonly IServiceChargesRepository _serviceChargesRepository;

        public ServiceChargeValidationSpecificationFactory(IServiceChargesRepository serviceChargesRepository)
        {
            _serviceChargesRepository = serviceChargesRepository;
        }

        public IValidationSpecification<ServiceCharge> GetCreatingValidationSpecification()
        {
            return new ServiceChargeCreatingValidationSpecyfication(_serviceChargesRepository);
        }

        public IValidationSpecification<ServiceCharge> GetDeletingValidationSpecification()
        {
            return new ServiceChargeDeletingValidationSpecyfication(_serviceChargesRepository);
        }
    }
}
