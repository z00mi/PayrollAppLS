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
    public class AffiliationValidationSpecificationFactory : IAffiliationValidationSpecificationFactory
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        private readonly IAffiliationsRepository _affiliationsRepository;

        public AffiliationValidationSpecificationFactory(
            IOrganizationsRepository organizationsRepository,
            IAffiliationsRepository affiliationsRepository)
        {
            _organizationsRepository = organizationsRepository;
            _affiliationsRepository = affiliationsRepository;
        }

        public IValidationSpecification<Affiliation> GetCreatingValidationSpecification()
        {
            return new AffiliationCreatingValidationSpecyfication(_organizationsRepository, _affiliationsRepository);
        }

        public IValidationSpecification<Affiliation> GetUpdatingValidationSpecification()
        {
            return new AffiliationUpdatingValidationSpecyfication(_affiliationsRepository);
        }

        public IValidationSpecification<Affiliation> GetDeletingValidationSpecification()
        {
            return new AffiliationDeletingValidationSpecyfication();
        }
    }
}
