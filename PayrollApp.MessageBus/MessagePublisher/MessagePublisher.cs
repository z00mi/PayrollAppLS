using System.Collections;

namespace PayrollApp.Infrastructure.MessageBus
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IList _messagesBuffer;
        private readonly MessageBus _messageBus;

        public MessagePublisher(MessageBus messageBus)
        {
            _messagesBuffer = new ArrayList();
            _messageBus = messageBus;
        }

        public void AddToSendBuffer<T>(T message)
        {
            _messagesBuffer.Add(message);
        }

        public void FlushBufferedMessages()
        {
            foreach (var message in _messagesBuffer)
            {
                _messageBus.Send(message);
            }
        }

        public void ClearBufferedMessages()
        {
            _messagesBuffer.Clear();
        }
    }
}
