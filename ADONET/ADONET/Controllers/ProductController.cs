using ADONET.DTO;
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
        public IActionResult SearchProductWithName([FromQuery] string productName)
        {
            return Ok(_productService.SearchProductWithName(productName));
        }

        [HttpGet("SearchProductWithNameUsingParameterizedQuery")]
        public IActionResult SearchProductWithNameUsingParameterizedQuery([FromQuery] string productName)
        {
            return Ok(_productService.SearchProductWithNameUsingParameterizedQuery(productName));
        }

        [HttpGet("SearchProductWithNameUsingStoredProcedure")]
        public IActionResult SearchProductWithNameUsingStoredProcedure([FromQuery] string productName)
        {
            return Ok(_productService.SearchProductWithNameUsingStoredProcedure(productName));
        }

        [HttpGet("GetAllProductsWithDiscountedPrice")]
        public IActionResult GetAllProductsWithDiscountedPrice()
        {
            return Ok(_productService.GetAllProductsWithDiscountedPrice());
        }
    }
}
