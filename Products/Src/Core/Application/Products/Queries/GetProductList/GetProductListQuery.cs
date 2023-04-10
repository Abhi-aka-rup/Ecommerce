using MediatR;

namespace ProductsAPI.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductsListVm>
    {
    }
}
