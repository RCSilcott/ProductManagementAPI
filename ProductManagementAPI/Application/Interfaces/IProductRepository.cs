using ProductManagementAPI.Domain.Models;

namespace ProductManagementAPI.Application.Interfaces
{
	public interface IProductRepository
	{
		public Task AddProduct(Product product);
	}
}
