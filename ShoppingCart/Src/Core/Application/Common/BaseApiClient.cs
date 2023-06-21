using ShoppingCartAPI.Application.Common.Interfaces;
using Polly;
using Polly.CircuitBreaker;
using Microsoft.AspNetCore.Http;

namespace ShoppingCartAPI.Application.Common
{
    public class BaseApiClient : IBaseApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpClient HttpClient => _httpClient;

        public AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreakerPolicy => _circuitBreakerPolicy;

        public IHttpContextAccessor HttpContextAccessor => _httpContextAccessor;

        public BaseApiClient(HttpClient httpClient, AsyncCircuitBreakerPolicy<HttpResponseMessage> circuitBreakerPolicy, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _circuitBreakerPolicy = circuitBreakerPolicy;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
