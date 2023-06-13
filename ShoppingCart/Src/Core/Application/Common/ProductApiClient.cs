using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;
using System.Net.Http.Json;

namespace ShoppingCartAPI.Application.Common
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly string PRODUCT_API_BASE_URI = "/api/products/{0}";
        private readonly IBaseApiClient _baseApiClient;

        public ProductApiClient(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }

        public async Task<Product> GetProductDetails(int productId)
        {
            string requestUri = string.Format(PRODUCT_API_BASE_URI, productId);
            HttpResponseMessage response = await _baseApiClient.CircuitBreakerPolicy.ExecuteAsync(async () =>
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                HttpResponseMessage response = await _baseApiClient.HttpClient.SendAsync(request);
                return response;
            });
            if(response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadFromJsonAsync<Product>();
            }

            return null;
        }
    }
}
