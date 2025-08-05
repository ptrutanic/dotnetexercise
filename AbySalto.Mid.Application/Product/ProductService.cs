using AbySalto.Mid.Domain.External;

namespace AbySalto.Mid.Application.Product
{
    public class ProductService(IProductApiFacade productApiFacade) : IProductService
    {
        private readonly IProductApiFacade _productApiFacade = productApiFacade;

        public Task<ProductListResponseDto> GetProductsAsync()
        {
            return _productApiFacade.GetProductsAsync();
        }
    }
}
