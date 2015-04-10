using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Repositories
{
    public interface IAffiliationsRepository : IRepository<Affiliation, AffiliationUid>
    {
        Affiliation GetBy(OrganizationUid organizationUid, AffiliationMemberId memberId);
        bool AffiliationExists(OrganizationUid organizationUid, AffiliationMemberId memberId, AffiliationUid exceptAffiliationUid = null);
        bool AffiliationExists(OrganizationUid organizationUid, EmployeeUid employeeUid, AffiliationUid exceptAffiliationUid);
    }
}
