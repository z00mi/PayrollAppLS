using System;

namespace PayrollApp.Domain.Model
{
    public class StringValueObject : ValueObject<StringValueObject>
    {
        private readonly string _string;

        protected StringValueObject(string @string)
        {
            _string = @string;
        }

        protected override int GetThisHashCode()
        {
            return _string.GetHashCode();
        }

        protected override bool ThisEquals(StringValueObject other)
        {
            return (other != null && other._string.Equals(_string));
        }

        protected override string ThisToString()
        {
            return _string;
        }

        public static implicit operator string(StringValueObject stringValueObject)
        {
            if (stringValueObject == null) return null;

            return stringValueObject._string;
        }
    }
}
