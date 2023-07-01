using Application.RabbitMQConsumer;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ShoppingCartAPI.Domain.Entities;
using System.Text;

namespace ShoppingCartAPI.Application.RabbitMQConsumer
{
    public class RabbitMQMessageConsumer : IRabbitMQMessageConsumer
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQMessageConsumer(string hostname, string username, string password)
        {
            _hostname = hostname;
            _username = username;
            _password = password;
        }

        public async Task<T> ConsumeMessage<T>()
        {
            if (ConnectionExists())
            {
                using (var _channel = _connection.CreateModel())
                {
                    var taskCompletionSrc = new TaskCompletionSource<T>();

                    _channel.QueueDeclare("responseProductDetails", false, false, false);
                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += (channel, eventArgs) =>
                    {
                        var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                        T message = JsonConvert.DeserializeObject<T>(content);
                        _channel.BasicAck(eventArgs.DeliveryTag, false);

                        taskCompletionSrc.SetResult(message);
                    };
                    _channel.BasicConsume("responseProductDetails", false, consumer);

                    return await taskCompletionSrc.Task;
                }
            }
            return default;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }
            CreateConnection();
            return _connection != null;
        }
    }
}
