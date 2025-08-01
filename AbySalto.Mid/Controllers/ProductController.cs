using AbySalto.Mid.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ProductService productService) : Controller
    {
        private readonly ProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
    }
}
