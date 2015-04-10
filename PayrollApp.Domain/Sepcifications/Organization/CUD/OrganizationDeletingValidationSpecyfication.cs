using System;
using System.Runtime.InteropServices;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Services;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationDeletingValidationSpecyfication : ValidationSpecification<Organization>
    {
        private readonly IOrganizationsService _organizationsService;

        public OrganizationDeletingValidationSpecyfication(IOrganizationsService organizationsService)
        {
            _organizationsService = organizationsService;
        }

        public override bool IsSatisfiedBy(Organization o, ref string failedMessages)
        {
            var organizationHasNotMembers = new OrganizationHasNotMembersSpecification(_organizationsService);

            return 
                organizationHasNotMembers
                .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
