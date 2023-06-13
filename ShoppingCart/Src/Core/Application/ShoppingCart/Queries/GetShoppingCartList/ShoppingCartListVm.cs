using Ecommerce.MessageBus;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class ShoppingCartListVm : BaseMessage
    {
        public IList<ShoppingCartDto> CartList { get; set; }
    }
}
