using ProductService.Models;
using ProductService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly ILogger<ProductController> _logger;

		public ProductController(IProductService productService, ILogger<ProductController> logger)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var products = await _productService.GetProducts();
			return Ok(products);
		}

		[HttpGet("{id}", Name = nameof(GetProductById))]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Product>> GetProductById(string id)
		{
			var product = await _productService.GetProduct(id);

            if (product == null)
			{
				_logger.LogError($"Product with id: {id}, not found.");
				return NotFound();
			}

			return Ok(product);
		}

		[Route("[action]/{category}", Name = nameof(GetProductByCategory))]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
		{
			var products = await _productService.GetProductByCategory(category);
			return Ok(products);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
		public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
		{
			await _productService.CreateProduct(product); 
			return CreatedAtRoute(nameof(GetProductById), new { id = product.Id }, product);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> UpdateProduct([FromBody] Product product)
		{
            await _productService.UpdateProduct(product);
            return NoContent();
		}

		[HttpDelete("{id}", Name = nameof(DeleteProductById))]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> DeleteProductById(string id)
		{
            await _productService.DeleteProduct(id);
            return NoContent();
        }
	}
}
