using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Services
{
    public interface IOrganizationsService
    {
        IntegerValueObject GetMembersCount(OrganizationUid uid);
        Money CalculateMonthlyBudget(OrganizationUid organizationUid);
    }
}
