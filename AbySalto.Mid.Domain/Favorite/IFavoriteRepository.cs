namespace AbySalto.Mid.Domain.Favorite
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> FindByUserIdAsync(int userId);
        Task AddAsync(Favorite favorite);
    }
}
