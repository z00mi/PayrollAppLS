using System;

namespace PayrollApp.Domain.Model
{
    public class IntegerValueObject : ValueObject<IntegerValueObject>
    {
        private readonly int _value;

        protected IntegerValueObject(int value)
        {
            _value = value;
        }

        public static IntegerValueObject Create(int value)
        {
            return new IntegerValueObject(value);
        }

        protected override int GetThisHashCode()
        {
            return _value.GetHashCode();
        }

        protected override bool ThisEquals(IntegerValueObject other)
        {
            return other != null && other._value.Equals(_value);
        }

        protected override string ThisToString()
        {
            return _value.ToString();
        }

        public static implicit operator int(IntegerValueObject valObj)
        {
            if(valObj == null) throw new ArgumentNullException("valObj");

            return valObj._value;
        }

        public static implicit operator IntegerValueObject(int value)
        {
            return Create(value);
        }
    }
}
