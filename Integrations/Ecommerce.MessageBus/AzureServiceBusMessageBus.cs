using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.MessageBus
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
        private readonly string connectionString = "Endpoint=sb://learning-microservice.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3BI1UTJrHHw/P7LnXGgrRh84sQDZjkfnB+ASbGSDatY=";

        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            await using var client = new ServiceBusClient(connectionString);
            ServiceBusSender sender = client.CreateSender(topicName);
            
            var jsonMsg = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMsg = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMsg))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(finalMsg);
            await client.DisposeAsync();
        }
    }
}
