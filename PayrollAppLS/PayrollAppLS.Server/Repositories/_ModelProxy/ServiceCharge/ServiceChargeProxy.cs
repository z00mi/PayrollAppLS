using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class ServiceChargeProxy : ServiceCharge
    {
        public ServiceChargeProxy(ServiceChargeUid uid, AffiliationUid affiliationUid, Date date, Money amount)
            : base(uid, affiliationUid, date, amount)
        {
        }
    }
}