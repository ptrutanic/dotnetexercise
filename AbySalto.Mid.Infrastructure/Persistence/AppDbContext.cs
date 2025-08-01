using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Cart> Carts { get; set; }
    }
}
