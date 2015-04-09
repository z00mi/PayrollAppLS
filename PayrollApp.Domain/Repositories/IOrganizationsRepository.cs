using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Repositories
{
    public interface IOrganizationsRepository : IRepository<Organization, OrganizationUid>
    {
        bool OrganizationExists(OrganizationName organizationName, OrganizationUid exceptOrganizationUid);
    }
}
