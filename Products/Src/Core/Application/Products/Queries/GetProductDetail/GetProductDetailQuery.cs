using MediatR;

namespace Products.Application.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public int ProductId { get; set; }
    }
}
