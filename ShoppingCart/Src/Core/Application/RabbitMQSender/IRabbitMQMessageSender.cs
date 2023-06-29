namespace ShoppingCartAPI.Application.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage<T>(T message, string queueName);
    }
}
