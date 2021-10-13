using ProductService.Models;
using MongoDB.Driver;

namespace ProductService.Repositories
{
	public interface IProductRepository
	{
		IMongoCollection<Product> Products { get; }
	}
}
