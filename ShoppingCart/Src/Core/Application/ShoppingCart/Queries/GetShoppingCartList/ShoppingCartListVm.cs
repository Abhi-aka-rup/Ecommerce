using Ecommerce.MessageBus;

namespace Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class ShoppingCartListVm : BaseMessage
    {
        public IList<ShoppingCartDto> CartList { get; set; }
    }
}
