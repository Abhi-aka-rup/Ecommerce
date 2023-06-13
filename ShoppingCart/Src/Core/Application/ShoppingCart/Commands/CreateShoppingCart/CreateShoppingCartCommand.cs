using MediatR;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommand : IRequest<int>
    {
        public int Count { get; set; }

        public int ProductId { get; set; }
    }
}
