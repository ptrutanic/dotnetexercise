namespace AbySalto.Mid.Domain.External
{
    public interface IProductApiFacade
    {
        Task<ProductListResponseDto> GetProductsAsync();
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Thumbnail { get; set; }
    }

    public class ProductListResponseDto
    {
        public ProductListResponseDto()
        {
            Products = [];
            Total = 0;
            Skip = 0;
            Limit = 0;
        }

        public List<ProductDto> Products { get; set; } = [];
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
