namespace AbySalto.Mid.Application.Dtos
{
    public class CartResponseDto
    {
        public List<CartItemResponseDto> CartItems { get; set; } = [];
        public decimal TotalPrice { get; set; }

        public static CartResponseDto MapFromCart(Domain.Cart.Cart? cart)
        {
            if (cart is null) return new CartResponseDto();

            var cartItems = CartItemResponseDto.MapAllFromCartItems(cart.CartItems);

            return new CartResponseDto
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(cartItem => cartItem.TotalPrice)
            };
        }
    }

    public class CartItemResponseDto
    {
        public static List<CartItemResponseDto> MapAllFromCartItems(List<Domain.Cart.CartItem>? cartItems)
        {
            if (cartItems == null || cartItems.Count == 0)
                return [];

            return cartItems.Select(cartItem => new CartItemResponseDto
            {
                ProductId = cartItem.ExternalProductId,
                Quantity = cartItem.Quantity,
                PricePerItem = cartItem.PricePerItem,
                TotalPrice = cartItem.TotalPrice
            }).ToList();
        }


        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalPrice { get; set; }
    }
}