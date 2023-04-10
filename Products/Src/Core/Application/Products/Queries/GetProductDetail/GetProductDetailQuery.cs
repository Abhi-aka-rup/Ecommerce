using MediatR;

namespace ProductsAPI.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public int ProductId { get; set; }
    }
}
