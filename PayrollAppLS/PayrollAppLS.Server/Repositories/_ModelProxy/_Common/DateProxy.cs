using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class DateProxy: Date
    {
        public DateProxy(DateTime date) : base(date)
        {
        }
    }
}