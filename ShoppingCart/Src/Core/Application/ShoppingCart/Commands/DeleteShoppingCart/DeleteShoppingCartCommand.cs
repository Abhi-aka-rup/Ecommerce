using MediatR;

namespace Application.ShoppingCart.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommand : IRequest<Unit>
    {
        public int CartDetailsId { get; set; }
    }
}
