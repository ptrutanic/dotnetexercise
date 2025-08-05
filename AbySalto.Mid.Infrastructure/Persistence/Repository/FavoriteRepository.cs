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

        public async Task<Favorite?> FindByUserAndProductAsync(int userId, int productId)
        {
            return await _db.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.ExternalProductId == productId);
        }

        public async Task DeleteAsync(Favorite favorite)
        {
            _db.Favorites.Remove(favorite);
            await _db.SaveChangesAsync();
        }
    }
}