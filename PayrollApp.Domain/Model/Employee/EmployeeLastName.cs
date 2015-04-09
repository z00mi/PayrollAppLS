using System;

namespace PayrollApp.Domain.Model
{
    public class EmployeeLastName : StringValueObject
    {
        protected EmployeeLastName(string lastName): base(lastName)
        {
        }

        public static EmployeeLastName Create(string lastName)
        {
            if (lastName == null) throw new ArgumentNullException("lastName");
            //TODO ograniczenia
            return new EmployeeLastName(lastName);
        }

        public static implicit operator EmployeeLastName(string lastName)
        {
            return Create(lastName);
        }
    }
}
