using Hub.Service.Models;
using MongoDB.Driver;

namespace Hub.Service.Repositories
{
	public interface IProductRepository
	{
		IMongoCollection<Product> Products { get; }
	}
}
