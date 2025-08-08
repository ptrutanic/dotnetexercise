namespace AbySalto.Mid.Domain.Cart
{
    public class Cart : BaseEntity
    {
        protected Cart() { }

        public Cart(int userId, List<CartItem> cartItems)
        {
            UserId = userId;
            CartItems = cartItems;
        }

        public void UpdateItems(List<CartItem> cartItems)
        {
            CartItems = cartItems ?? [];
        }

        public int UserId { get; private set; }
        public decimal TotalPrice => CartItems.Sum(item => item.TotalPrice);
        public virtual User.User User { get; private set; } = null!;
        public List<CartItem> CartItems { get; set; } = [];
    }

    public class CartItem
    {
        public CartItem(int externalProductId, string? title, decimal pricePerItem, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }

            if (pricePerItem < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(pricePerItem));
            }

            ExternalProductId = externalProductId;
            Quantity = quantity;
            PricePerItem = pricePerItem;
            Title = title;
        }

        public int ExternalProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public string? Title { get; set; } = "";
        public decimal TotalPrice => Quantity * PricePerItem;
    }
}
