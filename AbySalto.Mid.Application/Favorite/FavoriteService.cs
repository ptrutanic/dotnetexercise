using AbySalto.Mid.Domain.Favorite;

namespace AbySalto.Mid.Application.Favorite
{
    public class FavoriteService(IFavoriteRepository favoriteRepository) : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository = favoriteRepository;

        Task<List<Domain.Favorite.Favorite>> IFavoriteService.GetByUserIdAsync(int userId)
        {
            return _favoriteRepository.FindByUserIdAsync(userId);
        }
    }
}