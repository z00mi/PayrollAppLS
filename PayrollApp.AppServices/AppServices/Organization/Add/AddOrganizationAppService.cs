using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Events;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Services;

namespace PayrollApp.AppServices
{
    public class AddOrganizationAppService : IAddOrganizationAppService
    {
        private readonly IOrganizationsRepository _organizationRepository;
        private readonly IOrganizationValidationSpecificationFactory _validationSpecificationFactory;

        public AddOrganizationAppService(
            IOrganizationsRepository organizationRepository,
            IOrganizationValidationSpecificationFactory validationSpecificationFactory)
        {
            _organizationRepository = organizationRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public Guid Invoke(AddOrganizationData args)
        {
            var newOrganization = Organization.Create(
                args.Name,
                args.WebAddress != null ? WebAddress.Create(args.WebAddress) : null,
                _validationSpecificationFactory.GetCreatingValidationSpecification());

            _organizationRepository.Insert(newOrganization); 
            _organizationRepository.Save();

            return newOrganization.Uid;
        }
    }
}
