using System;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;

namespace PayrollApp.Domain.Sepcifications
{
    public class AffiliationDeletingValidationSpecyfication : ValidationSpecification<Affiliation>
    {
        //TODO może tu dodać warunek sprawdzania czy uregulowano zaległe płatnosci dla organizacji???

        public AffiliationDeletingValidationSpecyfication()
        {
        }

        public override bool IsSatisfiedBy(Affiliation o, ref string failedMessages)
        {
            return true;
        }
    }
}
