namespace ProductService.Contracts
{
    public interface IMessageProducer
    {
        Task SendMessage<T>(T message);
    }
}
