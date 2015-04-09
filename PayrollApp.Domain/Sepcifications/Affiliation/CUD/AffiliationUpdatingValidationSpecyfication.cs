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
            //return 
            //    _emailNotExists
            //    .And(_employeeFirstAndLastNameNotExists)
            //    .IsSatisfiedBy(o, ref failedMessages);

            return true;
        }
    }
}
