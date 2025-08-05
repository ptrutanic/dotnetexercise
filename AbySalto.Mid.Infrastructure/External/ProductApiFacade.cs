
using System.Text.Json;
using AbySalto.Mid.Domain.External;
using AbySalto.Mid.Infrastructure.Configuration;

namespace AbySalto.Mid.Infrastructure.External
{
    public class ProductApiFacade(HttpClient httpClient) : IProductApiFacade
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<ProductListResponseDto> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync(EnvConfig.PRODUCT_API_URL);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var productResponse = JsonSerializer.Deserialize<ProductListResponseDto>(content, JsonOptionsProvider.DefaultOptions);

            if (productResponse == null)
            {
                return new ProductListResponseDto();
            }

            return productResponse;
        }

        public async Task<ProductDetailsDto> GetProductDetailsAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"{EnvConfig.PRODUCT_API_URL}/{productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var productResponse = JsonSerializer.Deserialize<ProductDetailsDto>(content, JsonOptionsProvider.DefaultOptions);

            if (productResponse == null)
            {
                return new ProductDetailsDto();
            }

            return productResponse;
        }
    }
}
