using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Domain.User;
using AbySalto.Mid.Domain.Favorite;
using AbySalto.Mid.Domain.Cart;
using System.Text.Json;

namespace AbySalto.Mid.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var jsonSerializerOptions = new JsonSerializerOptions();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.IdentityProviderId)
                .IsUnique();

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity
                    .HasOne(f => f.User)
                    .WithMany(u => u.Favorites)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasIndex(f => new { f.UserId, f.ExternalProductId })
                    .IsUnique();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity
                    .HasOne(f => f.User)
                    .WithOne(u => u.Cart)
                    .HasForeignKey<Cart>(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(c => c.CartItems)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, jsonSerializerOptions),
                        v => JsonSerializer.Deserialize<List<CartItem>>(v, jsonSerializerOptions) ?? new List<CartItem>())
                    .HasColumnType("jsonb");

                entity
                    .HasIndex(u => u.UserId)
                    .IsUnique();
            });
        }
    }
}
