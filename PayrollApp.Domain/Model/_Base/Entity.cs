using System;

namespace PayrollApp.Domain.Model
{
    public abstract class Entity<TUid>
    {
        public TUid Uid { get; private set; }

        protected Entity(TUid uid)
        {
            if (uid == null) throw new ArgumentNullException("uid");

            Uid = uid;
        }

        #region comparision by Uid

        public override bool Equals(object obj)
        {
            return Uid.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Uid.GetHashCode();
        }

        public override string ToString()
        {
            return Uid.ToString();
        }

        #endregion
    }
}
