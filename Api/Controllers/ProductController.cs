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
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                var newProduct = _productService.AddProduct(product);
                return CreatedAtRoute("GetProduct", new {id = newProduct.Id}, newProduct);
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                return Ok(_productService.UpdateProduct(id, product));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
