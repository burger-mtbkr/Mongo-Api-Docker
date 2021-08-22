using Hub.Service.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hub.Service.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public IMongoCollection<Product> Products { get; }
		private readonly MongoClient _productClient;
		private readonly IMongoDatabase _database;

		public ProductRepository(IOptions<DatabaseSettings> settings)
		{
			_productClient = new MongoClient(settings.Value.ConnectionString);
			_database = _productClient.GetDatabase(settings.Value.DatabaseName);
			Products = _database.GetCollection<Product>(settings.Value.CollectionName);
		}
	}
}
