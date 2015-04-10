using System.Linq;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationWebAddressUniqueSpecyfication : ExpressionSpecification<Organization>
    {
        public OrganizationWebAddressUniqueSpecyfication(IOrganizationsRepository organizationRepository, OrganizationUid exceptOrganizationUid = null)
            : base(
                u => !organizationRepository.OrganizationExists(u.WebAddress, exceptOrganizationUid),
                "Istnieje organizacja z takim adresem web"
            )
        {
        }
    }
}
