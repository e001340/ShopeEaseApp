using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopEase.Domain.Entities;
using ShopEase.Infrastructure.Entities;

namespace ShopEase.Infrastructure
{
    public class ShopEaseDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopEaseDbContext(DbContextOptions<ShopEaseDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
