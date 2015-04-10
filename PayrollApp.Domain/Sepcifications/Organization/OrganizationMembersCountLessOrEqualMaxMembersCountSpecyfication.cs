using System.Linq;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationMembersCountLessOrEqualMaxMembersCountSpecyfication : ExpressionSpecification<Organization>
    {
        public OrganizationMembersCountLessOrEqualMaxMembersCountSpecyfication(IOrganizationsRepository organizationRepository)
            : base(
                u =>
                {
                    var organization = organizationRepository.Get(u.Uid);
                    return u.MaxMembersCount < organization.MembersCount;
                },
                "Liczba członków organizacji jest większa podana maksymalna liczba członków"
            )
        {
        }
    }
}
