using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class MoneyProxy: Money
    {
        public MoneyProxy(decimal money) : base(money)
        {
        }
    }
}