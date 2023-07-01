namespace Application.RabbitMQConsumer
{
    public interface IRabbitMQMessageConsumer
    {
        Task<T> ConsumeMessage<T>();
    }
}
