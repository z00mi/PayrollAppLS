using System;
using System.Collections.Generic;
using System.Linq;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Policies;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Model
{

    /// <summary>
    /// Reprezentuje Pracownika
    /// </summary>
    public class Employee : AggregateRoot<EmployeeUid>
    {
        private List<Address> _addresses;

        public EmployeeFirstName FirstName { get; private set; }
        public EmployeeLastName LastName { get; private set; }
        public NullableValObj<EmailAddress> Email { get; private set; }
        public NullableValObj<PhoneNumber> Phone { get; private set; }

        public EmployeePaymentScheduleType PaymentScheduleType { get; private set; }
        public PaymentClassification PaymentClassification { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        /// <summary>
        /// Konstruktor dla Repository (via proxy)
        /// </summary>
        protected Employee(
            EmployeeUid uid,
            EmployeeFirstName firstName,
            EmployeeLastName lastName,
            NullableValObj<EmailAddress> email,
            NullableValObj<PhoneNumber> phone,
            IEnumerable<Address> addresses,
            EmployeePaymentScheduleType paymentScheduleType,
            PaymentClassification paymentClassification,
            PaymentMethod paymentMethod)
            : base(uid)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            _addresses = addresses.ToList();
            PaymentScheduleType = paymentScheduleType;
            PaymentClassification = paymentClassification;
            PaymentMethod = paymentMethod;
        }

        /// <summary>
        /// Konstruktor dla Factory
        /// </summary>
        public static Employee Create(
            EmployeeFirstName firstName,
            EmployeeLastName lastName,
            NullableValObj<EmailAddress> email,
            NullableValObj<PhoneNumber> phone,
            IEnumerable<Address> addresses,
            EmployeePaymentScheduleType paymentScheduleType,
            PaymentClassification paymentClassification,
            PaymentMethod paymentMethod,
            IValidationSpecification<Employee> creatingValidationSpecification)
        {
            if (firstName == null) throw new ArgumentNullException("firstName");
            if (lastName == null) throw new ArgumentNullException("lastName");
            if (addresses == null) throw new ArgumentNullException("addresses");
            if (paymentClassification == null) throw new ArgumentNullException("paymentClassification");
            if (paymentMethod == null) throw new ArgumentNullException("paymentMethod");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var employee = new Employee(EmployeeUid.CreateNew(), firstName, lastName, email, phone, addresses, paymentScheduleType, paymentClassification, paymentMethod);

            if (!creatingValidationSpecification.IsSatisfiedBy(employee))
                throw new ValidationException("Nie można utworzyć pracownika", creatingValidationSpecification.GetValidationErrorMessages());

            return employee;
        }


        public IReadOnlyCollection<Address> Addresses
        {
            get { return _addresses.AsReadOnly(); }
        }


        public void Update(EmployeeFirstName firstName,
            EmployeeLastName lastName,
            NullableValObj<EmailAddress> email,
            NullableValObj<PhoneNumber> phone,
            IEnumerable<Address> addresses,
            EmployeePaymentScheduleType paymentScheduleType,
            PaymentClassification paymentClassification,
            PaymentMethod paymentMethod,
            IValidationSpecification<Employee> updatingValidationSpecification)
        {
            if (firstName == null) throw new ArgumentNullException("firstName");
            if (lastName == null) throw new ArgumentNullException("lastName");
            if (addresses == null) throw new ArgumentNullException("addresses");
            if (paymentClassification == null) throw new ArgumentNullException("paymentClassification");
            if (paymentMethod == null) throw new ArgumentNullException("paymentMethod");

            var tmpEmployee = new Employee(Uid, firstName, lastName, email, phone, addresses, paymentScheduleType, paymentClassification, paymentMethod);
            if (!updatingValidationSpecification.IsSatisfiedBy(tmpEmployee))
                throw new ValidationException("Nie można zaktualizować pracownika", updatingValidationSpecification.GetValidationErrorMessages());

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            _addresses = addresses.ToList();
            PaymentScheduleType = paymentScheduleType;
            PaymentClassification = paymentClassification;
            PaymentMethod = paymentMethod;
        }

        public void Delete(IValidationSpecification<Employee> deletingValidationSpecification)
        {
            if (deletingValidationSpecification == null) throw new ArgumentNullException("deletingValidationSpecification");

            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć pracownika", deletingValidationSpecification.GetValidationErrorMessages());
        }


        public bool IsPayDay(Date date, IPaymentScheduleCalculationPolicy paymentSchedulePolicy)
        {
            if (date == null) throw new ArgumentNullException("date");
            if (paymentSchedulePolicy == null) throw new ArgumentNullException("paymentSchedulePolicy");

            return paymentSchedulePolicy.IsPayDate(date);
        }

        public PayCheck GeneratePayCheck(IPaymentCalculationPolicy paymentCalculationPolicy, IDeductionsCalculationPolicy deductionsCalculationPolicy)
        {
            if (paymentCalculationPolicy == null) throw new ArgumentNullException("paymentCalculationPolicy");

            var payCheck = PayCheck.CreateNewEmptyPayCheck(this.Uid); 

            paymentCalculationPolicy.CalculatePay(ref payCheck);
            deductionsCalculationPolicy.CalculateDeductions(ref payCheck);

            return payCheck;
        }

        public void PerformPayment(PayCheck payCheck, IPerformPaymentPolicy performPaymentPolicy)
        {
            if (payCheck == null) throw new ArgumentNullException("payCheck");
            if (performPaymentPolicy == null) throw new ArgumentNullException("performPaymentPolicy");

            performPaymentPolicy.PerformPayment(payCheck);
        }
    }
}
