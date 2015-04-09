using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollApp.Domain.Model;

namespace PayrollApp.Infrastructure.Repositories
{
    public class AddressProxy : Address
    {
        public AddressProxy(AddressCity city, AddressStreet street, AddressNumber number) : base(city, street, number)
        {
        }
    }
}