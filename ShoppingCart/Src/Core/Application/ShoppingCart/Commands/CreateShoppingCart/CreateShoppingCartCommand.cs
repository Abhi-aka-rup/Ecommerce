using MediatR;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommand : IRequest<int>
    {
        public int Count { get; set; }

        public Product Product { get; set; }
    }
}
