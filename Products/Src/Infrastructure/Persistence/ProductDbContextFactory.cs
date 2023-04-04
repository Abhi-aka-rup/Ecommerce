using Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ProductDbContextFactory : DesignTimeDbContextFactoryBase<ProductDbContext>
    {
        protected override ProductDbContext CreateNewInstance(DbContextOptions<ProductDbContext> options)
        {
            return new ProductDbContext(options);
        }
    }
}
