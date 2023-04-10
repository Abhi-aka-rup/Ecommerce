using MediatR;

namespace Products.Application.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductsListVm>
    {
    }
}
