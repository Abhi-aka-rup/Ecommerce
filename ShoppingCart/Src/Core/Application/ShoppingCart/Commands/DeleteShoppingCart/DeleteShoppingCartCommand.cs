using MediatR;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommand : IRequest<Unit>
    {
        public int CartDetailsId { get; set; }
    }
}
