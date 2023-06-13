using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.Common.Interfaces
{
    public interface IProductApiClient
    {
        Task<Product> GetProductDetails(int productId);
    }
}
