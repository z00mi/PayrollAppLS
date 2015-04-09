using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class EmployeeFirstNameProxy : EmployeeFirstName
    {
        public EmployeeFirstNameProxy(string firstName) : base(firstName)
        {
        }
    }
}