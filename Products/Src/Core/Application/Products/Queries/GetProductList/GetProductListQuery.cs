using MediatR;

namespace Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductsListVm>
    {
    }
}
