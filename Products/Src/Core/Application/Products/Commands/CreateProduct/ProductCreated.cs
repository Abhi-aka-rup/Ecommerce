using Common.Interfaces;
using Common.Notifications.Models;
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public class ProductCreated : INotification
    {
        public int ProductId { get; set; }

        public class ProductCreatedHandler : INotificationHandler<ProductCreated>
        {
            private readonly INotificationService _notification;

            public ProductCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
            {
                return _notification.SendAsync(new MessageDto());
            }
        }
    }
}
