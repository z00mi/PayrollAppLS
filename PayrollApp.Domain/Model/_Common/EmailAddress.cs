using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Model
{
    public class EmailAddress : StringValueObject
    {
        protected internal EmailAddress(string email) : base(email)
        {
        }

        public static EmailAddress Create(string email)
        {
            if (email == null) throw new ArgumentNullException("email");
            //TODO - tu regular expr - spr maila
            return new EmailAddress(email);
        }
    }
}
