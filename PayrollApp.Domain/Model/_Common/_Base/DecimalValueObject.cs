using System;

namespace PayrollApp.Domain.Model
{
    public class DecimalValueObject : ValueObject<DecimalValueObject>
    {
        private readonly decimal _value;

        protected DecimalValueObject(decimal value)
        {
            _value = value;
        }

        protected override int GetThisHashCode()
        {
            return _value.GetHashCode();
        }

        protected override bool ThisEquals(DecimalValueObject other)
        {
            return other != null && other._value.Equals(_value);
        }

        protected override string ThisToString()
        {
            return _value.ToString();
        }

        public static implicit operator decimal(DecimalValueObject valObj)
        {
            if(valObj == null) throw new ArgumentNullException("valObj");

            return valObj._value;
        }
    }
}
