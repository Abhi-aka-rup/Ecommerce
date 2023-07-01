using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ProductsAPI.Application.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQMessageSender(string hostname, string username, string password)
        {
            _hostname = hostname;
            _username = username;
            _password = password;
        }

        public void SendMessage<T>(T message, string queueName)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queueName, false, false, false);
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish("", queueName, null, body);
            }
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
            if(_connection != null)
            {
                return true;
            }
            CreateConnection();
            return _connection != null;
        }
    }
}
