using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class PayrollProxy: Payroll
    {
        public PayrollProxy(PayrollUid uid, DateAndTime timeGenerated, IEnumerable<PayrollItem> payrollItems) : base(uid, timeGenerated, payrollItems)
        {
        }
    }
}