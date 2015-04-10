using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class EmployeeUniqueInOrganizationSpecification : ExpressionSpecification<Affiliation>
    {
        public EmployeeUniqueInOrganizationSpecification(IAffiliationsRepository affiliationsRepository, AffiliationUid exceptAffiliationUid = null)
            : base(
                u => !affiliationsRepository.AffiliationExists(u.OrganizationUid, u.EmployeeUid, exceptAffiliationUid),
                "Pracownik jest już członkiem tej organizacji"
            )
        {
        }
    }
}
