using PayrollApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Events
{
    public class MemberDuesChangedEvent: IDomainEvent
    {
        public Guid AffiliationUid { get; set; }

        public static MemberDuesChangedEvent Create(AffiliationUid affiliationUid)
        {
            if (affiliationUid == null) throw new ArgumentNullException("affiliationUid");

            return new MemberDuesChangedEvent
            {
                AffiliationUid = affiliationUid
            };
        }
    }
}
