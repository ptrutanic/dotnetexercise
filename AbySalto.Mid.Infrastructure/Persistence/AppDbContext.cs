using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Domain.User;
using AbySalto.Mid.Domain.Favorite;

namespace AbySalto.Mid.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            });
        }
    }
}
