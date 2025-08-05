
using AbySalto.Mid.Application.Dtos;
using AbySalto.Mid.Domain.Auth;
using AbySalto.Mid.Domain.External;
using AbySalto.Mid.Domain.Favorite;

namespace AbySalto.Mid.Application.Product
{
    public class ProductService(IProductApiFacade productApiFacade, IIdentity identity, IFavoriteRepository favoriteRepository) : IProductService
    {
        private readonly IProductApiFacade _productApiFacade = productApiFacade;
        private readonly IIdentity _identity = identity;
        private readonly IFavoriteRepository _favoriteRepository = favoriteRepository;

        public async Task<ProductListWithFavoritesDto> GetProductsAsync()
        {
            List<Favorite> userFavorites = await _favoriteRepository.FindByUserIdAsync(_identity.AppUserId);
            ProductListResponseDto productsResponse = await _productApiFacade.GetProductsAsync();

            var userFavoritesIds = userFavorites.Select(favorite => favorite.ExternalProductId);

            List<ProductWithFavoriteDto> combinedProducts = [.. productsResponse.Products
                .Select(product => new ProductWithFavoriteDto
                {
                    Id = product.Id,
                    Title = product.Title,
                    Thumbnail = product.Thumbnail,
                    Price = product.Price,
                    IsFavorite = userFavoritesIds.Contains(product.Id)
                })];

            return new ProductListWithFavoritesDto
            {
                Products = combinedProducts,
                Total = productsResponse.Total
            };
        }

        public async Task<bool> ToggleProductFavoriteAsync(int productId)
        {
            var favorite = await _favoriteRepository.FindByUserAndProductAsync(_identity.AppUserId, productId);

            if (favorite is not null)
            {
                await _favoriteRepository.DeleteAsync(favorite);
                return false;
            }
            else
            {
                await _favoriteRepository.AddAsync(new Favorite(_identity.AppUserId, productId));
                return true;
            }
        }
    }
}
