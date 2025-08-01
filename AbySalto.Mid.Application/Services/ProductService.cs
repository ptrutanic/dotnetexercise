using AbySalto.Mid.Domain.External;

namespace AbySalto.Mid.Application.Services
{
    public class ProductService(IProductApiFacade productApiFacade)
    {
        private readonly IProductApiFacade _productApiFacade = productApiFacade;

        public Task<ProductListResponseDto> GetProductsAsync()
        {
            return _productApiFacade.GetProductsAsync();
        }
    }
}
