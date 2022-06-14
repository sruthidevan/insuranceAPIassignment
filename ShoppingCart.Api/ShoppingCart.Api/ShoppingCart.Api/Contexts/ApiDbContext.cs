using InsuranceCalculator.Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCalculator.Api.Contexts
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        // Override EF configuration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CartItem>(b =>
            {
                b.HasKey(k => new {k.CartId, k.CatalogItemId});
                b.HasOne(p => p.Product);
                b.HasOne(p => p.Cart)
                    .WithMany(m => m.Products)
                    .HasForeignKey(k => k.CartId);
            });
        }

        public DbSet<Product> CatalogItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
