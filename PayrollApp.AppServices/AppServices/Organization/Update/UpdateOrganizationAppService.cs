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
    public class UpdateOrganizationAppService : IUpdateOrganizationAppService
    {
        private readonly IOrganizationsRepository _organizationRepository;
        private readonly IOrganizationValidationSpecificationFactory _validationSpecificationFactory;

        public UpdateOrganizationAppService(
            IOrganizationsRepository organizationRepository,
            IOrganizationValidationSpecificationFactory validationSpecificationFactory)
        {
            _organizationRepository = organizationRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(UpdateOrganizationData args)
        {
            var organization = _organizationRepository.Get(args.OrganizationUid);

            organization.Update(
                args.Name,
                args.WebAddress != null ? WebAddress.Create(args.WebAddress) : null,
                _validationSpecificationFactory.GetUpdatingValidationSpecification());

            _organizationRepository.Update(organization);
            _organizationRepository.Save();
        }
    }
}
