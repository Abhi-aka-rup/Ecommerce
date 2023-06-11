using Common.Behaviours;
using Ecommerce.MessageBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductsAPI.Application
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();

            return services;
        }
    }
}
