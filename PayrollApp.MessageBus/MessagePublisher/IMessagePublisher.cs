namespace PayrollApp.Infrastructure.MessageBus
{
    public interface IMessagePublisher
    {
        void AddToSendBuffer<T>(T message);
        void FlushBufferedMessages();
        void ClearBufferedMessages();
    }
}
