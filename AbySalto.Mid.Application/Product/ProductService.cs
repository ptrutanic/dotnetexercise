
using AbySalto.Mid.Domain.Auth;
using AbySalto.Mid.Domain.External;

namespace AbySalto.Mid.Application.Product
{
    public class ProductService(IProductApiFacade productApiFacade, IIdentity identity) : IProductService
    {
        private readonly IProductApiFacade _productApiFacade = productApiFacade;
        private readonly IIdentity _identity = identity;

        public Task<ProductListResponseDto> GetProductsAsync()
        {

            return _productApiFacade.GetProductsAsync();
        }
    }
}
