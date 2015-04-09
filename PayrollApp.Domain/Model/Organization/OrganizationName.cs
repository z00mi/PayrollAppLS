using System;

namespace PayrollApp.Domain.Model
{
    public class OrganizationName: StringValueObject
    {
        protected OrganizationName(string @string) : base(@string)
        {
        }

        public static OrganizationName Create(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            //TODO ogr
            return new OrganizationName(name);
        }

        public static implicit operator OrganizationName(string name)
        {
            return Create(name);
        }
    }
}
