using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class AffiliationProxy: Affiliation
    {
        public AffiliationProxy(AffiliationUid uid, EmployeeUid employeeUid, OrganizationUid organizationUid, AffiliationMemberId memberId, Money dues) : base(uid, employeeUid, organizationUid, memberId, dues)
        {
        }
    }
}