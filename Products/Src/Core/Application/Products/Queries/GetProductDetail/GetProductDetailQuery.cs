using MediatR;

namespace Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public int ProductId { get; set; }
    }
}
