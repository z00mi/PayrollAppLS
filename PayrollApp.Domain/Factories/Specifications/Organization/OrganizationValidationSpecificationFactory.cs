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
    public class OrganizationValidationSpecificationFactory : IOrganizationValidationSpecificationFactory
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public OrganizationValidationSpecificationFactory(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
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
            return new OrganizationDeletingValidationSpecyfication(_organizationsRepository);
        }
    }
}
