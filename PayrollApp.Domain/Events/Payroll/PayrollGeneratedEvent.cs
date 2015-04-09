using PayrollApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Domain.Events
{
    public class PayrollGeneratedEvent: IDomainEvent
    {
        public Guid PayrollUid { get; set; }

        public static PayrollGeneratedEvent Create(PayrollUid payrollUid)
        {
            if (payrollUid == null) throw new ArgumentNullException("payrollUid");

            return new PayrollGeneratedEvent
            {
                PayrollUid = payrollUid
            };
        }
    }
}
