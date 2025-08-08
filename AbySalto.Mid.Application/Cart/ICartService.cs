using AbySalto.Mid.Application.Dtos;

namespace AbySalto.Mid.Application.Cart
{
    public interface ICartService
    {
        Task<CartResponseDto> Update(CartDto cartDto);
        Task<CartResponseDto> Get();
    }
}