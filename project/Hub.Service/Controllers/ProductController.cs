using Hub.Service.Models;
using Hub.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hub.Service.Controllers
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

		[HttpGet("{id:length(24)}", Name = "GetProduct")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Product>> GetProductById(string id)
		{
			var product = await _productService.GetProduct(id); if (product == null)
			{
				_logger.LogError($"Product with id: {id}, not found.");
				return NotFound();
			}
			return Ok(product);
		}

		[Route("[action]/{category}", Name = "GetProductByCategory")]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
		{
			var products = await _productService.GetProductByCategory(category);
			return Ok(products);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
		{
			await _productService.CreateProduct(product); return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> UpdateProduct([FromBody] Product product)
		{
			return Ok(await _productService.UpdateProduct(product));
		}

		[HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> DeleteProductById(string id)
		{
			return Ok(await _productService.DeleteProduct(id));
		}
	}
}
