using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class MemberIdUniqueInOrganizationSpecification : ExpressionSpecification<Affiliation>
    {
        public MemberIdUniqueInOrganizationSpecification(IAffiliationsRepository affiliationsRepository, AffiliationUid exceptAffiliationUid = null)
            : base(
                u => !affiliationsRepository.AffiliationExists(u.OrganizationUid, u.MemberId, exceptAffiliationUid),
                "Isnieje członek organizacji o takim numerze id"
            )
        {
        }
    }
}
