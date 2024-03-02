using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Interfaces;

namespace ProductsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts() 
        {
            try 
            {
                return Ok(_productService.GetProduct(null));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SearchProducts/{productName}")]
        public IActionResult SearchProducts(string? productName) 
        {
            try
            {
                return Ok(_productService.GetProduct(productName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
