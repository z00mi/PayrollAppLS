using System;

namespace PayrollApp.Domain.Model
{
    public class EmployeeHRId : StringValueObject
    {

        protected EmployeeHRId(string HRId): base(HRId)
        {
        }

        public static EmployeeHRId Create(string HRId)
        {
            if (HRId == null) throw new ArgumentNullException("HRId");
            //TODO ograniczenia
            return new EmployeeHRId(HRId);
        }

        public static implicit operator EmployeeHRId(string HRId)
        {
            return Create(HRId);
        }

    }
}
