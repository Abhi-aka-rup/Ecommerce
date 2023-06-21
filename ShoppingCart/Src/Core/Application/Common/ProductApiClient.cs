using Microsoft.AspNetCore.Http;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace ShoppingCartAPI.Application.Common
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly string PRODUCT_API_ENDPOINT = "/api/products/get/{0}";
        private readonly string PRODUCT_API_PORT = "5074";
        private readonly IBaseApiClient _baseApiClient;

        public ProductApiClient(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }

        public async Task<Product> GetProductDetails(int productId)
        {
            HttpRequest httpRequest = _baseApiClient.HttpContextAccessor.HttpContext.Request;
            string baseUri = $"{httpRequest.Scheme}://{httpRequest.Host.Host}:{PRODUCT_API_PORT}";
            string requestUri = baseUri + string.Format(PRODUCT_API_ENDPOINT, productId);
            HttpResponseMessage response = await _baseApiClient.CircuitBreakerPolicy.ExecuteAsync(async () =>
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                HttpResponseMessage response = await _baseApiClient.HttpClient.SendAsync(request);
                return response;
            });
            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadFromJsonAsync<Product>();
                return product;
            }

            return null;
        }
    }
}
