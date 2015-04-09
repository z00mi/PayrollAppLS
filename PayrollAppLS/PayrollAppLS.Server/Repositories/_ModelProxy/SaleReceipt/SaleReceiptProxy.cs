using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class SaleReceiptProxy: SaleReceipt
    {
        public SaleReceiptProxy(SaleReceiptUid uid, EmployeeUid employeeUid, Date date, Money amount) : base(uid, employeeUid, date, amount)
        {
        }
    }
}