using System;

namespace PayrollApp.Domain.Model
{
    public class GuidValueObject: ValueObject<GuidValueObject>
    {
        private readonly Guid _uid;

        protected GuidValueObject(Guid uid)
        {
            _uid = uid;
        }

        protected override int GetThisHashCode()
        {
            return _uid.GetHashCode();
        }

        protected override bool ThisEquals(GuidValueObject other)
        {
            return (other != null && other._uid.Equals(_uid));
        }

        protected override string ThisToString()
        {
            return _uid.ToString();
        }

        public static implicit operator Guid(GuidValueObject entityUid)
        {
            if (entityUid == null) throw new ArgumentNullException("entityUid");

            return entityUid._uid;
        }
    }
}
