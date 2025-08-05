using AbySalto.Mid.Application.Dtos;

namespace AbySalto.Mid.Application.Product
{
    public interface IProductService
    {
        Task<ProductListWithFavoritesDto> GetProductsAsync();
    }
}