using System;

namespace PayrollApp.Domain.Model
{
    public class PayrollUid: GuidValueObject
    {
        protected PayrollUid(Guid uid) : base(uid)
        {
        }

        public static PayrollUid CreateNew()
        {
            return new PayrollUid(Guid.NewGuid());
        }

        public static PayrollUid Create(Guid uid)
        {
            return new PayrollUid(uid);
        }

        public static implicit operator PayrollUid(Guid uid)
        {
            return Create(uid);
        }
    }
}
