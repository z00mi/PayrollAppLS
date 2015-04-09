using System;
using PayrollApp.Domain.Exceptions;

namespace PayrollApp.Domain.Model
{
    public class CommisionedClassificationCommision : DecimalValueObject
    {

        protected CommisionedClassificationCommision(decimal percent): base(percent)
        {
        }

        public static CommisionedClassificationCommision Create(decimal percent)
        {
            if(percent < 0.0m || percent > 100.0m)
                throw new DomainException("Percent out of range. Valid percent range: 0.0 to 100.0");

            return new CommisionedClassificationCommision(percent);
        }

        public static implicit operator CommisionedClassificationCommision(decimal percent)
        {
            return Create(percent);
        }
    }
}
