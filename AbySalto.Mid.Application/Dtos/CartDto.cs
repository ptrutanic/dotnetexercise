namespace AbySalto.Mid.Application.Dtos
{
    public class CartDto
    {
        public List<CartItemDto> CartItems { get; set; } = [];

        public (bool IsValid, string? ErrorMessage) Validate()
        {
            var productIdSet = new HashSet<int>();

            foreach (var item in CartItems)
            {
                if (item.Quantity <= 0)
                {
                    return (false, "Quantity must be greater than 0 for all cart items.");
                }

                if (item.ProductId <= 0)
                {
                    return (false, "Product Id can not be negative number.");
                }

                if (!productIdSet.Add(item.ProductId))
                {
                    return (false, "Each product can appear only once in the cart.");
                }
            }

            return (true, null);
        }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}