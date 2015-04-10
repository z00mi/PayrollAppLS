using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Sepcifications;
using PayrollApp.Domain.Services;

namespace PayrollApp.Domain.Factories
{
    public class OrganizationValidationSpecificationFactory : IOrganizationValidationSpecificationFactory
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        private readonly IOrganizationsService _organizationsService;

        public OrganizationValidationSpecificationFactory(
            IOrganizationsRepository organizationsRepository,
            IOrganizationsService organizationsService)
        {
            _organizationsRepository = organizationsRepository;
            _organizationsService = organizationsService;
        }

        public IValidationSpecification<Organization> GetCreatingValidationSpecification()
        {
            return new OrganizationCreatingValidationSpecyfication(_organizationsRepository);
        }

        public IValidationSpecification<Organization> GetUpdatingValidationSpecification()
        {
            return new OrganizationUpdatingValidationSpecyfication(_organizationsRepository);
        }

        public IValidationSpecification<Organization> GetDeletingValidationSpecification()
        {
            return new OrganizationDeletingValidationSpecyfication(_organizationsService);
        }
    }
}
