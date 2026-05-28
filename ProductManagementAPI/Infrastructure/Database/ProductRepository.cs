using Dapper;
using ProductManagementAPI.Application.Interfaces;
using ProductManagementAPI.Domain.Models;
using System.Data;

namespace ProductManagementAPI.Infrastructure.Database
{

	public class ProductRepository : IProductRepository
	{
		private readonly IDbConnection _db;

		public ProductRepository(IDbConnection db)
		{
			_db = db;
		}
		public async Task AddProduct(Product product)
		{
			const string sql = @"
            INSERT INTO Products (Id, Name, Sku, Description, Price, Stock, CreatedAt)
            VALUES (@Id, @Name, @Sku, @Description, @Price, @Stock, @CreatedAt)";

			await _db.ExecuteAsync(sql, product);
		}

	}
}
