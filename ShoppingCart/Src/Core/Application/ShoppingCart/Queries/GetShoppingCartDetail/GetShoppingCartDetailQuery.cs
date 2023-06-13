using MediatR;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartDetail
{
    public class GetShoppingCartDetailQuery : IRequest<ShoppingCartVm>
    {
        public int CartDetailsId { get; set; }
    }
}
