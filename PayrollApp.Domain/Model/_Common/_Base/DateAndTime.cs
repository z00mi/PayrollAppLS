using System;

namespace PayrollApp.Domain.Model
{
    public class DateAndTime: ValueObject<DateAndTime>
    {
        private readonly DateTime _dateTime;

        protected DateAndTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public static DateAndTime Create(DateTime dateTime)
        {
            return new DateAndTime(dateTime);
        }

        protected override int GetThisHashCode()
        {
            return _dateTime.GetHashCode();
        }

        protected override bool ThisEquals(DateAndTime other)
        {
            return other != null && other._dateTime.Equals(_dateTime);
        }

        protected override string ThisToString()
        {
            return _dateTime.ToShortDateString();
        }

        public static implicit operator DateTime(DateAndTime dateAndTime)
        {
            if (dateAndTime == null) throw new ArgumentNullException("dateAndTime");

            return dateAndTime._dateTime;
        }
    }
}
