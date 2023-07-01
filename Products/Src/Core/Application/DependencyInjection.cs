using Common.Behaviours;
using Ecommerce.MessageBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Application.Common;
using ProductsAPI.Application.RabbitMQSender;
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
            services.AddHostedService<RabbitMQConsumer>();
            services.AddSingleton<IRabbitMQMessageSender>(provider =>
            {
                string hostname = "localhost";
                string username = "guest";
                string password = "guest";
                return new RabbitMQMessageSender(hostname, username, password);
            });
            //services.AddScoped<ServiceFactory>(p => p.GetService);

            return services;
        }
    }
}
