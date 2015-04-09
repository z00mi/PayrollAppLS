using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class PayrollItemProxy : PayrollItem
    {
        public PayrollItemProxy(EmployeeUid employeeUid, Money grossPay, Money deductions, Money netPay) : base(employeeUid, grossPay, deductions, netPay)
        {
        }
    }
}