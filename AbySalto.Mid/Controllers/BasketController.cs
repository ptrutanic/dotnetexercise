using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        [HttpGet]
        public IActionResult GetBaskets()
        {
            var baskets = new List<object>
            {
                new { Id = 1, Name = "Fruit Basket", Quantity = 5 },
                new { Id = 2, Name = "Vegetable Basket", Quantity = 3 }
            };

            return Ok(baskets);
        }
    }
}
