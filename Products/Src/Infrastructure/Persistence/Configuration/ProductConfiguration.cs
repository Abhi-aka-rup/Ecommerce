using Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Products.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductId).HasColumnName("ProductID");

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");
        }
    }
}
