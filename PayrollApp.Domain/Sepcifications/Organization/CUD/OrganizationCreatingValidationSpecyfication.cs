using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationCreatingValidationSpecyfication : ValidationSpecification<Organization>
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public OrganizationCreatingValidationSpecyfication(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public override bool IsSatisfiedBy(Organization o, ref string failedMessages)
        {
            var nameUnique = new OrganizationNameUniqueSpecyfication(_organizationsRepository);
            var webAddressUnique = new OrganizationWebAddressUniqueSpecyfication(_organizationsRepository);

            return 
                nameUnique 
                .And(webAddressUnique)
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
