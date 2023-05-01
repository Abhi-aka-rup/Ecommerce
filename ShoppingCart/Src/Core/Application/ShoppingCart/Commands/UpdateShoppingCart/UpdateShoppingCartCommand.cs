using MediatR;
using ShoppingCartAPI.Domain.Entities;

namespace Application.ShoppingCart.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommand : IRequest<Unit>
    {
        public int CartDetailsId { get; set; }

        public int Count { get; set; }
    }
}
