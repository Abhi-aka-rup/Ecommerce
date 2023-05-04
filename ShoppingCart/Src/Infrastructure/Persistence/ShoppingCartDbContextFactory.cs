using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Persistence;

namespace Persistence
{
    public class ShoppingCartDbContextFactory : DesignTimeDbContextFactoryBase<ShoppingCartDbContext>
    {
        protected override ShoppingCartDbContext CreateNewInstance(DbContextOptions<ShoppingCartDbContext> options)
        {
            return new ShoppingCartDbContext(options);
        }
    }
}
