using System;

namespace PayrollApp.Domain.Model
{
    public class ServiceChargeUid: GuidValueObject
    {
        protected ServiceChargeUid(Guid uid)
            : base(uid)
        {
        }

        public static ServiceChargeUid CreateNew()
        {
            return new ServiceChargeUid(Guid.NewGuid());
        }

        public static ServiceChargeUid Create(Guid uid)
        {
            return new ServiceChargeUid(uid);
        }

        public static implicit operator ServiceChargeUid(Guid uid)
        {
            return Create(uid);
        }
    }
}
