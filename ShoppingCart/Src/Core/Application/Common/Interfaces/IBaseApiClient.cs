using Polly.CircuitBreaker;

namespace ShoppingCartAPI.Application.Common.Interfaces
{
    public interface IBaseApiClient
    {
        HttpClient HttpClient { get; }
        AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreakerPolicy { get; }
    }
}
