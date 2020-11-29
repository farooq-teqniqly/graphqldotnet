using System;
using Microsoft.AspNetCore.Mvc;
using Teqniqly.Samples.Graphql.Models;
using Teqniqly.Samples.Graphql.Services;

namespace Teqniqly.Samples.Graphql.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProductsAsync());
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] IProduct product)
        {
            try
            {
                var newProduct = _productService.AddProductAsync(product);
                return CreatedAtRoute("GetProduct", new {id = newProduct.Id}, newProduct);
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] IProduct product)
        {
            try
            {
                return Ok(_productService.UpdateProductAsync(id, product));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
