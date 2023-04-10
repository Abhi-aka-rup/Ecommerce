using Common.Interfaces;
using Common.Notifications.Models;

namespace ShoppingCartAPI.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
