using AbySalto.Mid.Domain.User;
using Microsoft.EntityFrameworkCore;


namespace AbySalto.Mid.Infrastructure.Persistence.Repository
{
    public class UserRepository(AppDbContext db) : IUserRepository
    {
        private readonly AppDbContext _db = db;

        public async Task<User?> FindByIdentityProviderIdAsync(string identityProviderId)
        {
            return await _db.Users.Include(u => u.Cart).FirstOrDefaultAsync(u => u.IdentityProviderId == identityProviderId); ;
        }

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}