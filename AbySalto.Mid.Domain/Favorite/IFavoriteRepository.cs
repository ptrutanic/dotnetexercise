namespace AbySalto.Mid.Domain.Favorite
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> FindByUserIdAsync(int userId);
        Task<Favorite?> FindByUserAndProductAsync(int userId, int productId);
        Task AddAsync(Favorite favorite);
        Task DeleteAsync(Favorite favorite);
    }
}
