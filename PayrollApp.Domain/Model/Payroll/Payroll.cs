using System;
using System.Collections.Generic;
using System.Linq;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Reprezentuje wygenerowaną Listę Płac pracowników na dany dzień
    /// </summary>
    public class Payroll : AggregateRoot<PayrollUid>
    {
        private readonly List<PayrollItem> _payrollItems;

        /// <summary>
        /// Data wygenerowania Listy Płac
        /// </summary>
        public DateAndTime TimeGenerated { get; private set; }

        protected Payroll(PayrollUid uid, DateAndTime timeGenerated, IEnumerable<PayrollItem> payrollItems)
            : base(uid)
        {
            TimeGenerated = timeGenerated;
            _payrollItems = payrollItems.ToList();
        }

        public static Payroll Create(
            DateAndTime payrollTimeGenerated,
            IValidationSpecification<Payroll> creatingValidationSpecification)
        {
            if (payrollTimeGenerated == null) throw new ArgumentNullException("payrollTimeGenerated");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var newPayroll = new Payroll(PayrollUid.CreateNew(), payrollTimeGenerated, new List<PayrollItem>());

            if (!creatingValidationSpecification.IsSatisfiedBy(newPayroll))
                throw new ValidationException("Nie można utworzyć listy płac", creatingValidationSpecification.GetValidationErrorMessages());

            return newPayroll;
        }

        public void Delete(IValidationSpecification<Payroll> deletingValidationSpecification)
        {
            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć listy płac", deletingValidationSpecification.GetValidationErrorMessages());            
        }

        public IReadOnlyCollection<PayrollItem> PayrollItems
        {
            get { return _payrollItems.AsReadOnly(); }
        }

        public void AddEmployeePayCheck(EmployeeUid employeeUid, PayCheck payCheck)
        {
            var item = PayrollItem.Create(employeeUid, payCheck.GrossPay, payCheck.Deductions, payCheck.NetPay);
            _payrollItems.Add(item);
        }
    }
}
