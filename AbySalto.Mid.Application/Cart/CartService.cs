using AbySalto.Mid.Application.Dtos;
using AbySalto.Mid.Application.Product;
using AbySalto.Mid.Domain.Auth;
using AbySalto.Mid.Domain.Cart;
using AbySalto.Mid.Domain.User;

namespace AbySalto.Mid.Application.Cart
{
    public class CartService(IIdentity identity, IUserRepository userRepository, IProductService productService) : ICartService
    {
        private readonly IIdentity _identity = identity;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IProductService _productService = productService;

        public async Task<CartResponseDto> Get()
        {
            var user = await _userRepository.FindByIdentityProviderIdAsync(_identity.IdentityProviderId);

            if (user is null) throw new InvalidOperationException("User not found for the given identity provider ID.");

            return CartResponseDto.MapFromCart(user.Cart);
        }

        public async Task<CartResponseDto> Update(CartDto cartDto)
        {
            var user = await _userRepository.FindByIdentityProviderIdAsync(_identity.IdentityProviderId);

            if (user is null) throw new InvalidOperationException("User not found for the given identity provider ID.");

            var cartItems = (await Task.WhenAll(
                cartDto.CartItems.Select(async cartItemDto =>
                {
                    var product = await _productService.GetProductByIdAsync(cartItemDto.ProductId);

                    if (product == null)
                        throw new InvalidOperationException($"Product not found: {cartItemDto.ProductId}");

                    return new CartItem(cartItemDto.ProductId, product.Title, product.Price, cartItemDto.Quantity);
                })
            )).ToList();

            if (user.Cart is null)
            {
                user.Cart = new Domain.Cart.Cart(user.Id, cartItems);
            }
            else
            {
                user.Cart.UpdateItems(cartItems);
            }

            await _userRepository.UpdateAsync(user);
            return CartResponseDto.MapFromCart(user.Cart);
        }
    }
}
