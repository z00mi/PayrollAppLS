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
            //return 
            //    _emailNotExists
            //    .And(_employeeFirstAndLastNameNotExists)
            //    .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
