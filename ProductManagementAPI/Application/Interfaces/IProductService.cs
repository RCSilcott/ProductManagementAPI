using ProductManagementAPI.Api.Requests;
using ProductManagementAPI.Domain.Models;

namespace ProductManagementAPI.Application.Interfaces
{
	public interface IProductService
	{
		Task<Product> CreateAsync(CreateProductRequest request);
	}
}
