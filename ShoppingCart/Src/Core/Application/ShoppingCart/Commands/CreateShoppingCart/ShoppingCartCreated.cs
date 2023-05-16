using Common.Interfaces;
using MediatR;

namespace Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class ShoppingCartCreated : INotification
    {
        public int CartDetailsId { get; set; }

        public class ShoppingCartCreatedHandler : INotificationHandler<ShoppingCartCreated>
        {
            private readonly INotificationService _notificationService;

            public ShoppingCartCreatedHandler(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            public Task Handle(ShoppingCartCreated notification, CancellationToken cancellationToken)
            {
                return _notificationService.SendAsync(new Common.Notifications.Models.MessageDto());
            }
        }
    }
}
