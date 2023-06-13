﻿using Common.Behaviours;
using Ecommerce.MessageBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using ShoppingCartAPI.Application.Common;
using ShoppingCartAPI.Application.Common.Interfaces;
using System.Reflection;

namespace ShoppingCartAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddScoped<IBaseApiClient, BaseApiClient>();
            services.AddScoped<IProductApiClient, ProductApiClient>();
            services.AddHttpClient<IBaseApiClient, BaseApiClient>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();
            services.AddSingleton<AsyncCircuitBreakerPolicy<HttpResponseMessage>>(serviceProvider =>
            {
                return Policy<HttpResponseMessage>
                    .Handle<Exception>()
                    .CircuitBreakerAsync(
                        handledEventsAllowedBeforeBreaking: 3,
                        durationOfBreak: TimeSpan.FromSeconds(30),
                        onBreak: (ex, breakDelay) =>
                        {
                            Console.WriteLine("Circuit breaker is open. Product API is unavailable.");
                            Console.WriteLine("Exception: " + ex);
                        },
                        onReset: () =>
                        {
                            Console.WriteLine("Circuit breaker is reset. API is available again.");
                        },
                        onHalfOpen: () =>
                        {
                            Console.WriteLine("Circuit breaker is in a half-open state. Testing API availability.");
                        }
                    );
            });

            return services;
        }
    }
}
