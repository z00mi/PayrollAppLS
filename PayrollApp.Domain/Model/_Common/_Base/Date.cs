using System;

namespace PayrollApp.Domain.Model
{
    public class Date: ValueObject<Date>
    {
        private readonly DateTime _date;

        protected Date(DateTime date)
        {
            _date = date;
        }

        public static Date Create(DateTime date)
        {
            return  new Date(date.Date);
        }

        protected override int GetThisHashCode()
        {
            return _date.GetHashCode();
        }

        protected override bool ThisEquals(Date other)
        {
            return other != null && other._date.Equals(_date);
        }

        protected override string ThisToString()
        {
            return _date.ToShortDateString();
        }

        public static implicit operator DateTime(Date date)
        {
            if (date == null) throw new ArgumentNullException("date");

            return date._date;
        }

        public static implicit operator Date(DateTime date)
        {
            return Create(date);
        }
    }
}
