using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Domain;

namespace SmartInventory.Api.Data
{
    public sealed class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(b => {
                b.Property(x => x.Name).HasMaxLength(200).IsRequired();
                b.Property(x => x.Sku).HasMaxLength(100);
                b.Property(x => x.Price).HasPrecision(18, 2);
            });
        }

    }
}
