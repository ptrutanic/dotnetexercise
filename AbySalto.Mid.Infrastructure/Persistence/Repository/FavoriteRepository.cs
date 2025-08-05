using AbySalto.Mid.Domain.Favorite;
using Microsoft.EntityFrameworkCore;


namespace AbySalto.Mid.Infrastructure.Persistence.Repository
{
    public class FavoriteRepository(AppDbContext db) : IFavoriteRepository
    {
        private readonly AppDbContext _db = db;

        public async Task<List<Favorite>> FindByUserIdAsync(int userId)
        {
            return await _db.Favorites.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Favorite Favorite)
        {
            _db.Favorites.Add(Favorite);
            await _db.SaveChangesAsync();
        }
    }
}