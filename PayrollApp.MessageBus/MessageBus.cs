using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebus;
using Rebus.Configuration;
using Rebus.Logging;
using Rebus.Transports.Msmq;

namespace PayrollApp.Infrastructure.MessageBus
{
    public class MessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IContainerAdapter adapter)
        {
            _bus = Configure.With(adapter)
                    .Logging(l => l.None())
                    .Transport(t => t.UseMsmqAndGetInputQueueNameFromAppConfig())
                    .MessageOwnership(d => d.FromRebusConfigurationSection())
                    .CreateBus()
                    .Start();
        }

        public void Send<T>(T message)
        {
            _bus.Send(message);
        }
    }
}
