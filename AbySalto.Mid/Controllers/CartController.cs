using AbySalto.Mid.Application.Cart;
using AbySalto.Mid.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(ICartService cartService) : Controller
    {
        private readonly ICartService _cartService = cartService;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var cart = await _cartService.Get();
            return Ok(cart);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upsert([FromBody] CartDto cartDto)
        {
            var (isValid, errorMessage) = cartDto.Validate();
            if (!isValid)
                return BadRequest(errorMessage);

            try
            {
                var cart = await _cartService.Update(cartDto);
                return Ok(cart);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
