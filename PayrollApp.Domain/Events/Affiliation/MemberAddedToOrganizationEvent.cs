using PayrollApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Events
{
    public class MemberAddedToOrganizationEvent: IDomainEvent
    {
        public Guid OrganizationUid { get; set; }

        public static MemberAddedToOrganizationEvent Create(OrganizationUid organizationUid)
        {
            if (organizationUid == null) throw new ArgumentNullException("organizationUid");

            return new MemberAddedToOrganizationEvent
            {
                OrganizationUid = organizationUid
            };
        }
    }
}
