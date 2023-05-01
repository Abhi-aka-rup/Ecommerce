using MediatR;

namespace Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class GetShoppingCartListQuery : IRequest<ShoppingCartListVm>
    {
    }
}
