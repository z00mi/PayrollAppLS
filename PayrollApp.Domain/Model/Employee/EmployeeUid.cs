using System;

namespace PayrollApp.Domain.Model
{
    public class EmployeeUid: GuidValueObject
    {
        protected EmployeeUid(Guid uid)
            : base(uid)
        {
        }

        public static EmployeeUid CreateNew()
        {
            return new EmployeeUid(Guid.NewGuid());
        }

        public static EmployeeUid Create(Guid uid)
        {
            return new EmployeeUid(uid);
        }

        public static implicit operator EmployeeUid(Guid entityUid)
        {
            return Create(entityUid);
        }
    }
}
