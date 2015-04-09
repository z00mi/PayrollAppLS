using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class IntegerValueObjectProxy: IntegerValueObject
    {
        public IntegerValueObjectProxy(int value) : base(value)
        {
        }
    }
}