using System;

namespace PayrollApp.Domain.Model
{
    public class Hours: ValueObject<Hours>
    {
        private readonly TimeSpan _hours;

        protected Hours(TimeSpan hours)
        {
            _hours = hours;
        }

        protected Hours(double hours)
        {
            _hours = TimeSpan.FromHours(hours);
        }

        public static Hours Create(TimeSpan hours)
        {
            return new Hours(hours);
        }

        protected override int GetThisHashCode()
        {
            return _hours.GetHashCode();
        }

        protected override bool ThisEquals(Hours other)
        {
            return other != null && other._hours.Equals(_hours);
        }

        protected override string ThisToString()
        {
            return _hours.ToString();
        }

        public static implicit operator TimeSpan(Hours hours)
        {
            if (hours == null) throw new ArgumentNullException("hours");

            return hours._hours;
        }

        public static implicit operator double(Hours hours)
        {
            if (hours == null) throw new ArgumentNullException("hours");

            return hours._hours.TotalHours;
        }

        public static implicit operator Hours(double hours)
        {
            return new Hours(hours);
        }
    }
}
