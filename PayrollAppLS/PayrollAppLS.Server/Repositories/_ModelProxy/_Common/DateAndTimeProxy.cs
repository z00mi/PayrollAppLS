using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class DateAndTimeProxy: DateAndTime
    {
        public DateAndTimeProxy(DateTime dateTime) : base(dateTime)
        {
        }
    }
}