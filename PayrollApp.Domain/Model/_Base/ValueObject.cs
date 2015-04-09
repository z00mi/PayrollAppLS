namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Value Object bez sprawdzania ==
    /// </summary>
    public abstract class ValueObject
    {
        
    }

    /// <summary>
    /// Value Object ze sprawdzaniem ==
    /// </summary>
    public abstract class ValueObject<TValObj> : ValueObject
    {

        #region comparision by value

        public override int GetHashCode()
        {
            return GetThisHashCode();
        }

        public override bool Equals(object obj)
        {
            return ThisEquals((TValObj)obj);
        }

        public override string ToString()
        {
            return ThisToString();
        }

        protected abstract int GetThisHashCode();
        protected abstract bool ThisEquals(TValObj other);
        protected abstract string ThisToString();

        #endregion
    }

}
