using System;

namespace PayrollApp.Domain.Model
{
    public class EmployeeFirstName : StringValueObject
    {

        protected EmployeeFirstName(string firstName): base(firstName)
        {
        }

        public static EmployeeFirstName Create(string firstName)
        {
            if (firstName == null) throw new ArgumentNullException("firstName");
            //TODO ograniczenia
            return new EmployeeFirstName(firstName);
        }

        public static implicit operator EmployeeFirstName(string firstName)
        {
            return Create(firstName);
        }

    }
}
