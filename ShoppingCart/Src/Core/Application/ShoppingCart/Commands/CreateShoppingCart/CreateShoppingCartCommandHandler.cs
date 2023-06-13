using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, int>
    {
        private readonly IShoppingCartDbContext _context;
        private readonly IMediator _mediator;
        private readonly IProductApiClient _productApiClient;

        public CreateShoppingCartCommandHandler(IShoppingCartDbContext context, IMediator mediator, IProductApiClient productApiClient)
        {
            _context = context;
            _mediator = mediator;
            _productApiClient = productApiClient;
        }

        public async Task<int> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            int cartId = await HandleShoppingCartDetailsAsync(request);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ShoppingCartCreated() { CartDetailsId = cartId }, cancellationToken);

            return cartId;
        }

        private async Task<int> HandleShoppingCartDetailsAsync(CreateShoppingCartCommand request)
        {
            var product = await _productApiClient.GetProductDetails(request.ProductId);
            var cartDetails = new CartDetails()
            {
                Count = request.Count,
                Product = product
            };
            _context.CartDetails.Add(cartDetails);

            return cartDetails.CartDetailsId;
        }
    }
}
