namespace Rwe.App.Abstractions
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}