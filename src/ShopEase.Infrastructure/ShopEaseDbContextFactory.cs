using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopEase.Infrastructure
{
    public class ShopEaseDbContextFactory : IDesignTimeDbContextFactory<ShopEaseDbContext>
    {
        public ShopEaseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopEaseDbContext>();
            // Update the connection string as needed for your environment
            optionsBuilder.UseSqlite("Data Source=ShopEase.db");
            return new ShopEaseDbContext(optionsBuilder.Options);
        }
    }
}