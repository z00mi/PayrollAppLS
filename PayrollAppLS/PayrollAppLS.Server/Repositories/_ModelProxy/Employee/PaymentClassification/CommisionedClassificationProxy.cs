using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class CommisionedClassificationProxy : CommisionedClassification
    {
        public CommisionedClassificationProxy(Money salary, CommisionedClassificationCommision commision) : base(salary, commision)
        {
        }
    }
}