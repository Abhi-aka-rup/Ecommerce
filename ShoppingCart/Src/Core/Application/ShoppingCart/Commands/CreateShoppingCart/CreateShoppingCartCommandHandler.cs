using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Application.RabbitMQSender;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, int>
    {
        private readonly IShoppingCartDbContext _context;
        private readonly IMediator _mediator;
        private readonly IProductApiClient _productApiClient;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;

        public CreateShoppingCartCommandHandler(IShoppingCartDbContext context, IMediator mediator, IProductApiClient productApiClient, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _context = context;
            _mediator = mediator;
            _productApiClient = productApiClient;
            _rabbitMQMessageSender = rabbitMQMessageSender;
        }

        public async Task<int> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            CartDetails cartDetails = await HandleShoppingCartDetailsAsync(request);

            _context.CartDetails.Add(cartDetails);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ShoppingCartCreated() { CartDetailsId = cartDetails.CartDetailsId }, cancellationToken);

            return cartDetails.CartDetailsId;
        }

        private async Task<CartDetails> HandleShoppingCartDetailsAsync(CreateShoppingCartCommand request)
        {
            //RabbitMQ
            _rabbitMQMessageSender.SendMessage(request, "getProductDetails");

            var product = await _productApiClient.GetProductDetails(request.ProductId);
            if (product != null)
            {
                var cartDetails = new CartDetails()
                {
                    Count = request.Count,
                    ProductId = product.ProductId
                };

                return cartDetails;
            }
            return null;
        }
    }
}
