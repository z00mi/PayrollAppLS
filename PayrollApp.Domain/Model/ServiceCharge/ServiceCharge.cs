using System;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Zgłoszenie dodatkowych płatności Pracownika na rzecz Organizacji
    /// </summary>
    public class ServiceCharge : AggregateRoot<ServiceChargeUid>
    {
        public AffiliationUid AffiliationUid { get; private set; }
        public Date Date { get; private set; }
        public Money Amount { get; private set; }

        protected ServiceCharge(ServiceChargeUid uid, AffiliationUid affiliationUid, Date date, Money amount)
            : base(uid)
        {
            AffiliationUid = affiliationUid;
            Date = date;
            Amount = amount;
        }

        public static ServiceCharge Create(
            AffiliationUid affiliationUid,
            Date date,
            Money amount,
            IValidationSpecification<ServiceCharge> creatingValidationSpecification)
        {
            if (affiliationUid == null) throw new ArgumentNullException("affiliationUid");
            if (date == null) throw new ArgumentNullException("date");
            if (amount == null) throw new ArgumentNullException("amount");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var newServiceCharge = new ServiceCharge(ServiceChargeUid.CreateNew(), affiliationUid, date, amount);

            if (!creatingValidationSpecification.IsSatisfiedBy(newServiceCharge))
                throw new ValidationException("Nie można utworzyć dodatkowj płatności na rzecz organizacji", creatingValidationSpecification.GetValidationErrorMessages());

            return newServiceCharge;
        }

        public void Delete(IValidationSpecification<ServiceCharge> deletingValidationSpecification)
        {
            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć dodatkowej płatności na rzecz organizacji", deletingValidationSpecification.GetValidationErrorMessages());
        }
    }
}
