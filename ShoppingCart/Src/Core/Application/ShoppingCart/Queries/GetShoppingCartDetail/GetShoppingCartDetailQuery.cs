using MediatR;

namespace Application.ShoppingCart.Queries.GetShoppingCartDetail
{
    public class GetShoppingCartDetailQuery : IRequest<ShoppingCartVm>
    {
        public int CartDetailsId { get; set; }
    }
}
