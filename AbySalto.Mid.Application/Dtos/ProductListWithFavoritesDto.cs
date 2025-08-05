namespace AbySalto.Mid.Application.Dtos
{

    public class ProductListWithFavoritesDto
    {
        public List<ProductWithFavoriteDto> Products { get; set; } = [];
        public int Total { get; set; }
    }

    public class ProductWithFavoriteDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Thumbnail { get; set; }
        public bool IsFavorite { get; set; }
    }
}