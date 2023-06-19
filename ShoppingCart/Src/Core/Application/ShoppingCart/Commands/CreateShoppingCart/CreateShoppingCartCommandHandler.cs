using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;
using System.Threading;

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
            CartDetails cartDetails = await HandleShoppingCartDetailsAsync(request);
           
            _context.CartDetails.Add(cartDetails);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ShoppingCartCreated() { CartDetailsId = cartDetails.CartDetailsId }, cancellationToken);

            return cartDetails.CartDetailsId;
        }

        private async Task<CartDetails> HandleShoppingCartDetailsAsync(CreateShoppingCartCommand request)
        {
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
