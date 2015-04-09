using System;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Dane odnośnie sprzedaży zgłoszone przez Pracownika pracującego w systemie prowizyjnym
    /// </summary>
    public class SaleReceipt : AggregateRoot<SaleReceiptUid>
    {
        public EmployeeUid EmployeeUid { get; private set; }
        public Date Date { get; private set; }
        public Money Amount { get; private set; }

        protected SaleReceipt(SaleReceiptUid uid, EmployeeUid employeeUid, Date date, Money amount)
            : base(uid)
        {
            EmployeeUid = employeeUid;
            Date = date;
            Amount = amount;
        }

        public static SaleReceipt Create(
            EmployeeUid employeeUid,
            Date date,
            Money amount,
            IValidationSpecification<SaleReceipt> creatingValidationSpecification)
        {
            if (employeeUid == null) throw new ArgumentNullException("employeeUid");
            if (date == null) throw new ArgumentNullException("date");
            if (amount == null) throw new ArgumentNullException("amount");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var newSaleReceipt = new SaleReceipt(SaleReceiptUid.CreateNew(), employeeUid, date, amount);

            if (!creatingValidationSpecification.IsSatisfiedBy(newSaleReceipt))
                throw new ValidationException("Nie można utworzyć zgłoszenia sprzedaży", creatingValidationSpecification.GetValidationErrorMessages());

            return newSaleReceipt;
        }

        public void Delete(IValidationSpecification<SaleReceipt> deletingValidationSpecification)
        {
            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć zgłoszenia sprzedaży", deletingValidationSpecification.GetValidationErrorMessages());
        }
    }
}
