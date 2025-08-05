using AbySalto.Mid.Domain.External;

namespace AbySalto.Mid.Application.Product
{
    public interface IProductService
    {
        Task<ProductListResponseDto> GetProductsAsync();
    }
}