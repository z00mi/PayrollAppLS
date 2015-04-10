using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class AffiliationUpdatingValidationSpecyfication : ValidationSpecification<Affiliation>
    {
        private readonly IAffiliationsRepository _affiliationsRepository;

        public AffiliationUpdatingValidationSpecyfication(IAffiliationsRepository affiliationsRepository)
        {
            _affiliationsRepository = affiliationsRepository;
        }

        public override bool IsSatisfiedBy(Affiliation o, ref string failedMessages)
        {
            var memberIdUniqueInOrganization = new MemberIdUniqueInOrganizationSpecification(_affiliationsRepository, o.Uid);
            var employeeUniqueInOrganization = new EmployeeUniqueInOrganizationSpecification(_affiliationsRepository, o.Uid);

            return
                memberIdUniqueInOrganization
                .And(employeeUniqueInOrganization)
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
