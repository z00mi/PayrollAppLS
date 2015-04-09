using System;

namespace PayrollApp.Domain.Model
{
    public class OrganizationUid: GuidValueObject
    {
        protected OrganizationUid(Guid uid) : base(uid)
        {
        }

        public static OrganizationUid CreateNew()
        {
            return new OrganizationUid(Guid.NewGuid());
        }

        public static OrganizationUid Create(Guid uid)
        {
            return new OrganizationUid(uid);
        }

        public static implicit operator OrganizationUid(Guid uid)
        {
            return Create(uid);
        }
    }
}
