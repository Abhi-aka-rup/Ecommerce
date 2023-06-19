using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCartAPI.Application.Common.Interfaces;

namespace ShoppingCartAPI.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ShoppingCartDatabase")));

            services.AddScoped<IShoppingCartDbContext>(provider => provider.GetService<ShoppingCartDbContext>());

            return services;
        }
    }
}
