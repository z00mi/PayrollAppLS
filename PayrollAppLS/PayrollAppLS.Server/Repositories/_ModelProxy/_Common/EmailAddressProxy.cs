using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class EmailAddressProxy: EmailAddress
    {
        public EmailAddressProxy(string email) : base(email)
        {
        }
    }
}