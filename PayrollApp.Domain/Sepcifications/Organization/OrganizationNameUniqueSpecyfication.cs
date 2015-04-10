using System.Linq;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationNameUniqueSpecyfication : ExpressionSpecification<Organization>
    {
        public OrganizationNameUniqueSpecyfication(IOrganizationsRepository organizationRepository, OrganizationUid exceptOrganizationUid = null)
            : base(
                u => !organizationRepository.OrganizationExists(u.Name, exceptOrganizationUid),
                "Istnieje organizacja z taką nazwą"
            )
        {
        }
    }
}
