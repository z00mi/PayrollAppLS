using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Reprezentuje value object'y które mogą być null'owe
    /// </summary>
    public struct NullableValObj<TValueObject> where TValueObject : ValueObject
    {
        private readonly TValueObject _valueObj;

        private NullableValObj(TValueObject instanceOrNull)
        {
            _valueObj = instanceOrNull;
        }

        /// <summary>
        /// True jeśli wartość != null
        /// </summary>
        public bool HasValue
        {
            get { return _valueObj != null; }
        }

        /// <summary>
        /// Zwraca value object lub null
        /// </summary>
        public TValueObject Value
        {
            get { return _valueObj; }
        }


        #region override

        public override string ToString()
        {
            return _valueObj != null ? _valueObj.ToString() : "null";
        }

        #endregion


        #region converting

        public static implicit operator TValueObject(NullableValObj<TValueObject> nullableValObj)
        {
            return nullableValObj._valueObj;
        }

        public static implicit operator NullableValObj<TValueObject>(TValueObject valObj)
        {
            return new NullableValObj<TValueObject>(valObj);
        }

        #endregion


        #region comparision

        public override bool Equals(object other)
        {
            return (_valueObj == null && other == null)
                || (_valueObj != null && other != null && _valueObj.Equals(other));
        }

        public override int GetHashCode()
        {
            return _valueObj != null ? _valueObj.GetHashCode() : 0;
        }

        
        public static bool operator ==(NullableValObj<TValueObject> a, NullableValObj<TValueObject> b)
        {
            //if (ReferenceEquals(a, b))
            //{
            //    return true;
            //}

            return (a._valueObj == null && b._valueObj == null)
                || (a._valueObj != null && b._valueObj != null && a._valueObj.Equals(b._valueObj));
        }

        public static bool operator !=(NullableValObj<TValueObject> a, NullableValObj<TValueObject> b)
        {
            return !(a == b);
        }
        
        #endregion

    }
}
