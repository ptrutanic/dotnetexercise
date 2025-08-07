using AbySalto.Mid.Application.Dtos;
using AbySalto.Mid.Domain.External;

namespace AbySalto.Mid.Application.Product
{
    public interface IProductService
    {
        Task<ProductListWithFavoritesDto> GetProductsAsync(int page, string? sortByPrice);
        Task<ProductDetailsDto> GetProductByIdAsync(int productId);
        Task<bool> ToggleProductFavoriteAsync(int productId);
    }
}