using ProductsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Application.Common.Interfaces
{
    public interface IProductDbContext
    {
        public DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
