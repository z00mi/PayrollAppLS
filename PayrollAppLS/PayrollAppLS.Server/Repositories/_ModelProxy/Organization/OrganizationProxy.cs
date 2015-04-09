using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class OrganizationProxy: Organization
    {
        public OrganizationProxy(OrganizationUid uid, OrganizationName name, NullableValObj<WebAddress> webAddress, IntegerValueObject membersCount, Money monthlyBudget) : base(uid, name, webAddress, membersCount, monthlyBudget)
        {
        }
    }
}