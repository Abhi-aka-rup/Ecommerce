using MediatR;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class GetShoppingCartListQuery : IRequest<ShoppingCartListVm>
    {
    }
}
