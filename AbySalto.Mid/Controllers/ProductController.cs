using AbySalto.Mid.Application.Product;
using AbySalto.Mid.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpPost("favorite")]
        [Authorize]
        public async Task<IActionResult> Favorite([FromBody] FavoriteProductDto favoriteProductDto)
        {
            var isFavorite = await _productService.ToggleProductFavoriteAsync(favoriteProductDto.Id);
            return Ok(new { isFavorite });
        }
    }
}
