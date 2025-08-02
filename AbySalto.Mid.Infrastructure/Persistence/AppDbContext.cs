using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Domain.User;

namespace AbySalto.Mid.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.IdentityProviderId)
                .IsUnique();
        }
    }
}
