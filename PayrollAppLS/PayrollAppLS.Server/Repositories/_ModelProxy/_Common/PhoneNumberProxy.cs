using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class PhoneNumberProxy: PhoneNumber
    {
        public PhoneNumberProxy(string phone)
            : base(phone)
        {
        }
    }
}