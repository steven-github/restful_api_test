using Microsoft.AspNetCore.Mvc;
using restful_api_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace restful_api_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Mock database (for demonstration purposes)
        private static List<Product> _products = new List<Product>
        {
            new Product { ProductID = 1, Name = "Product A", Price = 10.00M },
            new Product { ProductID = 2, Name = "Product B", Price = 20.00M },
            new Product { ProductID = 3, Name = "Product C", Price = 30.00M }
        };

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is missing.");
            }
            _products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            _products.Remove(product);
            return NoContent();
        }
    }
}
