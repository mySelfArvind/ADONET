using ADONET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }
        [HttpGet("SearchProductWithName")]
        public async Task<IActionResult> SearchProductWithName([FromQuery] string productName)
        {
            return Ok(_productService.SearchProductWithName(productName));
        }
    }
}
