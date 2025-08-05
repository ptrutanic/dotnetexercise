namespace AbySalto.Mid.Application.Favorite
{
    public interface IFavoriteService
    {
        Task<List<Domain.Favorite.Favorite>> GetByUserIdAsync(int userId);
    }
}