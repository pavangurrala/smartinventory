using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartInventory.Api.Data
{
    public sealed class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=PAVAN-GURRALA\\SQLEXPRESS;Database=SmartInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
        
    }
}
