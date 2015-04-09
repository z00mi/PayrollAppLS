using System;

namespace PayrollApp.Domain.Model
{
    public class SaleReceiptUid: GuidValueObject
    {
        protected SaleReceiptUid(Guid uid) : base(uid)
        {
        }

        public static SaleReceiptUid CreateNew()
        {
            return new SaleReceiptUid(Guid.NewGuid());
        }

        public static SaleReceiptUid Create(Guid uid)
        {
            return new SaleReceiptUid(uid);
        }

        public static implicit operator SaleReceiptUid(Guid uid)
        {
            return Create(uid);
        }
    }
}
