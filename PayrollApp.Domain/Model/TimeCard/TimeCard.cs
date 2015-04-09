using System;
using PayrollApp.Domain.Exceptions;
using PayrollApp.Domain.Sepcifications;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Karta czasu pracy zgłaszana przez Pracownika pracującego w systemie godzinowym
    /// </summary>
    public class TimeCard : AggregateRoot<TimeCardUid>
    {
        public EmployeeUid EmployeeUid { get; private set; }
        public Date Date { get; private set; }
        public Hours Hours { get; private set; }
        
        protected TimeCard(TimeCardUid uid, EmployeeUid employeeUid, Date date, Hours hours) : base(uid)
        {
            EmployeeUid = employeeUid;
            Date = date;
            Hours = hours;
        }

        public static TimeCard Create(
            EmployeeUid employeeUid,
            Date date,
            Hours hours,
            IValidationSpecification<TimeCard> creatingValidationSpecification)
        {
            if (employeeUid == null) throw new ArgumentNullException("employeeUid");
            if (date == null) throw new ArgumentNullException("date");
            if (hours == null) throw new ArgumentNullException("hours");
            if (creatingValidationSpecification == null) throw new ArgumentNullException("creatingValidationSpecification");

            var newTimeCart = new TimeCard(TimeCardUid.CreateNew(), employeeUid, date, hours);

            if (!creatingValidationSpecification.IsSatisfiedBy(newTimeCart))
                throw new ValidationException("Nie można utworzyć karty czasu pracy", creatingValidationSpecification.GetValidationErrorMessages());

            return newTimeCart;
        }

        public void Delete(IValidationSpecification<TimeCard> deletingValidationSpecification)
        {
            if (!deletingValidationSpecification.IsSatisfiedBy(this))
                throw new ValidationException("Nie można usunąć karty czasu pracy", deletingValidationSpecification.GetValidationErrorMessages());
        }
    }
}
