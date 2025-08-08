namespace AbySalto.Mid.Domain.User
{
    public interface IUserRepository
    {
        Task<User?> FindByIdentityProviderIdAsync(string identityProviderId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
