using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Factories;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.AppServices
{
    public class DeleteOrganizationAppService : IDeleteOrganizationAppService
    {
        private readonly IOrganizationsRepository _organizationRepository;
        private readonly IOrganizationValidationSpecificationFactory _validationSpecificationFactory;

        public DeleteOrganizationAppService(
            IOrganizationsRepository organizationRepository,
            IOrganizationValidationSpecificationFactory validationSpecificationFactory)
        {
            _organizationRepository = organizationRepository;
            _validationSpecificationFactory = validationSpecificationFactory;
        }

        public void Invoke(Guid uid)
        {
            var organization = _organizationRepository.Get(uid);

            organization.Delete(_validationSpecificationFactory.GetDeletingValidationSpecification());

            _organizationRepository.Delete(organization);
            _organizationRepository.Save();
        }
    }
}
