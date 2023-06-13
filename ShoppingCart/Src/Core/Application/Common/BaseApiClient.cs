using ShoppingCartAPI.Application.Common.Interfaces;
using Polly;
using Polly.CircuitBreaker;

namespace ShoppingCartAPI.Application.Common
{
    public class BaseApiClient : IBaseApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy;

        public HttpClient HttpClient => _httpClient;

        public AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreakerPolicy => _circuitBreakerPolicy;

        public BaseApiClient(HttpClient httpClient, AsyncCircuitBreakerPolicy<HttpResponseMessage> circuitBreakerPolicy)
        {
            _httpClient = httpClient;
            _circuitBreakerPolicy = circuitBreakerPolicy;
        }
    }
}
