using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class AffiliationCreatingValidationSpecyfication : ValidationSpecification<Affiliation>
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        private readonly IAffiliationsRepository _affiliationsRepository;

        public AffiliationCreatingValidationSpecyfication(
            IOrganizationsRepository organizationsRepository,
            IAffiliationsRepository affiliationsRepository)
        {
            _organizationsRepository = organizationsRepository;
            _affiliationsRepository = affiliationsRepository;
        }

        public override bool IsSatisfiedBy(Affiliation o, ref string failedMessages)
        {
            var maxMembersInOrganization = new NotMaxMembersInOrganizationSpecification(_organizationsRepository);
            var memberIdUniqueInOrganization = new MemberIdUniqueInOrganizationSpecification(_affiliationsRepository);
            var employeeUniqueInOrganization = new EmployeeUniqueInOrganizationSpecification(_affiliationsRepository);

            return
                maxMembersInOrganization
                .And(memberIdUniqueInOrganization)
                .And(employeeUniqueInOrganization)
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
