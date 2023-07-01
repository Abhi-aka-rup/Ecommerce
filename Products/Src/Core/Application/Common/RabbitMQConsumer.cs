using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProductsAPI.Application.Products.Queries.GetProductDetail;
using ProductsAPI.Application.RabbitMQSender;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProductsAPI.Application.Common
{
    public class RabbitMQConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMQConsumer(IRabbitMQMessageSender rabbitMQMessageSender, IServiceProvider serviceProvider)
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
            _rabbitMQMessageSender = rabbitMQMessageSender;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, eventArgs) =>
            {
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                GetProductDetailQuery getProductDetailQuery = JsonConvert.DeserializeObject<GetProductDetailQuery>(content);
                using(var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    HandleMessage(mediator, getProductDetailQuery).GetAwaiter().GetResult();
                }
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume("getProductDetails", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(IMediator mediator, GetProductDetailQuery getProductDetailQuery)
        {
            var product = await mediator.Send(getProductDetailQuery);
            _rabbitMQMessageSender.SendMessage(product, "responseProductDetails");
            await Task.CompletedTask;
        }
    }
}
