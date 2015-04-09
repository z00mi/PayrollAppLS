using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Repositories
{
    public interface IAffiliationsRepository : IRepository<Affiliation, AffiliationUid>
    {
        Affiliation GetBy(OrganizationUid organizationUid, AffiliationMemberId memberId);
    }
}
