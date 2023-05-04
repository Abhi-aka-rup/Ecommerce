using Common.Domain;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;

namespace Persistence
{
    public class ShoppingCartDbContext : DbContext, IShoppingCartDbContext
    {
        private readonly IDateTime _dateTime;

        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options, IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartDbContext).Assembly);
        }
    }
}
