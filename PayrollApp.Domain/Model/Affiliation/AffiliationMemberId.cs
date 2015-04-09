using System;

namespace PayrollApp.Domain.Model
{
    public class AffiliationMemberId: StringValueObject
    {
        protected AffiliationMemberId(string memberId)
            : base(memberId)
        {
        }

        public static AffiliationMemberId Create(string memberId)
        {
            if (memberId == null) throw new ArgumentNullException("memberId");

            return new AffiliationMemberId(memberId);
        }

        public static implicit operator AffiliationMemberId(string memberId)
        {
            return Create(memberId);
        }
    }
}
