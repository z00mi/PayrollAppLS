using PayrollApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Events
{
    public class MemberRemovedFromOrganizationEvent: IDomainEvent
    {
        public Guid OrganizationUid { get; set; }

        public static MemberRemovedFromOrganizationEvent Create(OrganizationUid organizationUid)
        {
            if (organizationUid == null) throw new ArgumentNullException("organizationUid");

            return new MemberRemovedFromOrganizationEvent
            {
                OrganizationUid = organizationUid
            };
        }
    }
}
