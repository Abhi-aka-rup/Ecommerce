using Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Products.Application.Common.Interfaces
{
    public interface IProductDbContext
    {
        public DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
