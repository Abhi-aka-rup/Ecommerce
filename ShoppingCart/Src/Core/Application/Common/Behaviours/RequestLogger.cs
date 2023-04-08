using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : notnull
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<RequestLogger<TRequest>> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("ShoppingCart Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
