using Dapper;
using ProductManagementAPI.Api.Requests;
using ProductManagementAPI.Application.Interfaces;
using ProductManagementAPI.Domain.Models;
using ProductManagementAPI.Infrastructure;

namespace ProductManagementAPI.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository)
		{
			_repository = repository;
		}

		public async Task<Product> CreateAsync(CreateProductRequest request)
		{
			var product = new Product()
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Description = request.Description,
				Price = request.Price,
				Sku = request.Sku,
				Stock = request.Stock,
				CreatedAt = DateTime.UtcNow
			};

			await _repository.AddProduct(product);

			return product;
		}

		public async Task<ProductDto?> GetByIdAsync(Guid id)
		{
			var product = await _repository.GetByIdAsync(id);
			return product == null ? null : new ProductDto(product);
		}

	}
}
