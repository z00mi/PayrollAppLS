using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class NotMaxMembersInOrganizationSpecification : ExpressionSpecification<Affiliation>
    {
        public NotMaxMembersInOrganizationSpecification(IOrganizationsRepository organizationsRepository)
            : base(
                u =>
                {
                    var organization = organizationsRepository.Get(u.OrganizationUid);
                    return organization.MembersCount < organization.MaxMembersCount;
                },
                "Osiągnięto limit członków organizacji"
            )
        {
        }
    }
}
