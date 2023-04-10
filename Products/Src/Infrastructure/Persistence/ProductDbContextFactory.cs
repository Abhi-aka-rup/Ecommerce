using Microsoft.EntityFrameworkCore;

namespace Products.Persistence
{
    public class ProductDbContextFactory : DesignTimeDbContextFactoryBase<ProductDbContext>
    {
        protected override ProductDbContext CreateNewInstance(DbContextOptions<ProductDbContext> options)
        {
            return new ProductDbContext(options);
        }
    }
}
