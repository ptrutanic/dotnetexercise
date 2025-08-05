
using AbySalto.Mid.Application.Dtos;
using AbySalto.Mid.Application.Favorite;
using AbySalto.Mid.Domain.Auth;
using AbySalto.Mid.Domain.External;

namespace AbySalto.Mid.Application.Product
{
    public class ProductService(IProductApiFacade productApiFacade, IIdentity identity, IFavoriteService favoriteService) : IProductService
    {
        private readonly IProductApiFacade _productApiFacade = productApiFacade;
        private readonly IIdentity _identity = identity;
        private readonly IFavoriteService _favoriteService = favoriteService;

        public async Task<ProductListWithFavoritesDto> GetProductsAsync()
        {
            List<Domain.Favorite.Favorite> userFavorites = await _favoriteService.GetByUserIdAsync(_identity.AppUserId);
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
    }
}
