using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationUpdatingValidationSpecyfication : ValidationSpecification<Organization>
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public OrganizationUpdatingValidationSpecyfication(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public override bool IsSatisfiedBy(Organization o, ref string failedMessages)
        {
            var nameUnique = new OrganizationNameUniqueSpecyfication(_organizationsRepository, o.Uid);
            var webAddressUnique = new OrganizationWebAddressUniqueSpecyfication(_organizationsRepository, o.Uid);
            var membersCountLessOrEqualMaxMembersCount = new OrganizationMembersCountLessOrEqualMaxMembersCountSpecyfication(_organizationsRepository);

            return 
                nameUnique 
                .And(webAddressUnique)
                .And(membersCountLessOrEqualMaxMembersCount)
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
