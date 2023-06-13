using Microsoft.EntityFrameworkCore;

namespace ShoppingCartAPI.Persistence
{
    public class ShoppingCartDbContextFactory : DesignTimeDbContextFactoryBase<ShoppingCartDbContext>
    {
        protected override ShoppingCartDbContext CreateNewInstance(DbContextOptions<ShoppingCartDbContext> options)
        {
            return new ShoppingCartDbContext(options);
        }
    }
}
