using Ecommerce.MessageBus;

namespace ProductsAPI.Application.Products.Queries.GetProductList
{
    public class ProductsListVm : BaseMessage
    {
        public IList<ProductDto> Products { get; set; }
    }
}
