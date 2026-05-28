using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Api.Requests;
using ProductManagementAPI.Application.Interfaces;
using ProductManagementAPI.Domain.Models;

namespace ProductManagementAPI.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		//private readonly ILogger<ProductsController> _logger;

		public ProductController(IProductService productService)
		{
			_productService = productService;
			//_logger = logger;
		}

		[HttpPost("products")]
		public async Task<IActionResult> CreateProduct ([FromBody] CreateProductRequest request)
		{
			var newProduct = await _productService.CreateAsync(request);

			return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
		}

		// GET /api/products/{id}
		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetProductById(Guid id)
		{
			var product = await _productService.GetByIdAsync(id);
			return product is null ? NotFound() : Ok(product);
		}

		// GET /api/products
		// Optional filters: name, sku, minPrice, maxPrice, inStockOnly, etc.
		[HttpGet]
		public async Task<IActionResult> GetProducts([FromQuery] ProductQueryRequest query)
		{
			var products = await _productService.GetListAsync(query);
			return Ok(products);
		}

		// PUT /api/products/{id}
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
		{
			var updated = await _productService.UpdateAsync(id, request);
			return updated is null ? NotFound() : Ok(updated);
		}

		// PATCH /api/products/{id}
		[HttpPatch("{id:guid}")]
		public async Task<IActionResult> PatchProduct(Guid id, [FromBody] PatchProductRequest request)
		{
			var updated = await _productService.PatchAsync(id, request);
			return updated is null ? NotFound() : Ok(updated);
		}

		// DELETE /api/products/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			var deleted = await _productService.DeleteAsync(id);
			return deleted ? NoContent() : NotFound();
		}

		// PATCH /api/products/{id}/stock
		[HttpPatch("{id:guid}/stock")]
		public async Task<IActionResult> AdjustStock(Guid id, [FromBody] AdjustStockRequest request)
		{
			var updated = await _productService.AdjustStockAsync(id, request);
			return updated is null ? NotFound() : Ok(updated);
		}

		// GET /api/products/sku/{sku}
		[HttpGet("sku/{sku}")]
		public async Task<IActionResult> GetBySku(string sku)
		{
			var product = await _productService.GetBySkuAsync(sku);
			return product is null ? NotFound() : Ok(product);
		}

	}
}
