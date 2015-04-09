using System;

namespace PayrollApp.Domain.Model
{
    public class TimeCardUid: GuidValueObject
    {
        protected TimeCardUid(Guid uid)
            : base(uid)
        {
        }

        public static TimeCardUid CreateNew()
        {
            return new TimeCardUid(Guid.NewGuid());
        }

        public static TimeCardUid Create(Guid uid)
        {
            return new TimeCardUid(uid);
        }

        public static implicit operator TimeCardUid(Guid uid)
        {
            return Create(uid);
        }
    }
}
