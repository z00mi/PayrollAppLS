using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Events;
using Rebus;

namespace PayrollApp.EventHandlers
{
    public class PayrollGeneratedEventHandler : IHandleMessages<PayrollGeneratedEvent>
    {
        public void Handle(PayrollGeneratedEvent msg)
        {
            //TODO
        }
    }
}
