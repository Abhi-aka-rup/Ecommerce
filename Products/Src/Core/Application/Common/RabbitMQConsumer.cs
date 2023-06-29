using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProductsAPI.Application.Products.Queries.GetProductDetail;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace ProductsAPI.Application.Common
{
    public class RabbitMQConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQConsumer()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("getProductDetails", false, false, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, eventArgs) =>
            {
                var x = eventArgs;
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                GetProductDetailQuery getProductDetailQuery = JsonConvert.DeserializeObject<GetProductDetailQuery>(content);
                HandleMessage(getProductDetailQuery).GetAwaiter().GetResult();

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume("getProductDetails", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(GetProductDetailQuery getProductDetailQuery)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
