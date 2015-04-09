using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Model
{
    public class PhoneNumber: StringValueObject
    {
        protected internal PhoneNumber(string phone)
            : base(phone)
        {
        }

        public static PhoneNumber Create(string phone)
        {
            if (phone == null) throw new ArgumentNullException("phone");
            //TODO - tu regular expr - spr nr tel
            return new PhoneNumber(phone);
        }
    }
}
