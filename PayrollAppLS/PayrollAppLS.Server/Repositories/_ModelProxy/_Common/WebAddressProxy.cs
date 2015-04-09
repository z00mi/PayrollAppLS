using System;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class WebAddressProxy: WebAddress
    {
        public WebAddressProxy(string url)
            : base(url)
        {
        }
    }
}