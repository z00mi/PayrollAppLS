using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationCreatingValidationSpecyfication : ValidationSpecification<Organization>
    {
        private readonly OrganizationNameNotExistsSpecyfication _nameNotExists;

        public OrganizationCreatingValidationSpecyfication(IOrganizationsRepository organizationsRepository)
        {
            _nameNotExists = new OrganizationNameNotExistsSpecyfication(organizationsRepository);
        }

        public override bool IsSatisfiedBy(Organization o, ref string failedMessages)
        {
            return _nameNotExists 
                .IsSatisfiedBy(o, ref failedMessages);
        }
    }
}
