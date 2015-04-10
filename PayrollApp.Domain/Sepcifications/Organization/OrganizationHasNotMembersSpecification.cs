using System.Linq;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Services;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Sepcifications
{
    public class OrganizationHasNotMembersSpecification : ExpressionSpecification<Organization>
    {
        public OrganizationHasNotMembersSpecification(IOrganizationsService organizationsService)
            : base(
                u => organizationsService.GetMembersCount(u.Uid) == 0,
                "Organizacja posiada członków"
            )
        {
        }
    }
}
