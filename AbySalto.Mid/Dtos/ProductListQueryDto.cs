namespace AbySalto.Mid.WebApi.Dtos
{
    public class ProductListQueryDto
    {
        public string SortByPrice { get; set; } = "";
        public int Page { get; set; }

        public (bool IsValid, string? ErrorMessage) Validate()
        {

            if (Page < 1)
                return (false, "'page' must be >= 1");

            var validSortOrders = new[] { "asc", "desc", "" };
            if (!validSortOrders.Contains(SortByPrice, StringComparer.OrdinalIgnoreCase))
            {
                return (false, "'sortOrder' must be 'asc' or 'desc'");
            }

            return (true, null);
        }
    }
}