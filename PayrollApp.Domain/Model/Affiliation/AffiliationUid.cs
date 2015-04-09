using System;

namespace PayrollApp.Domain.Model
{
    public class AffiliationUid: GuidValueObject
    {
        protected AffiliationUid(Guid uid) : base(uid)
        {
        }

        public static AffiliationUid CreateNew()
        {
            return new AffiliationUid(Guid.NewGuid());
        }

        public static AffiliationUid Create(Guid uid)
        {
            return new AffiliationUid(uid);
        }

        public static implicit operator AffiliationUid(Guid entityUid)
        {
            return Create(entityUid);
        }
    }
}
