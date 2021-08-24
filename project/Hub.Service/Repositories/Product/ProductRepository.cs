using Hub.Service.Infrastructure.MongoDb;
using Hub.Service.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hub.Service.Repositories
{
	public class ProductRepository : IProductRepository
	{	
		private readonly IMongoDatabase _db;

		public ProductRepository(IOptions<MongoDBConfig> config)
		{
			var client = new MongoClient(config.Value.ConnectionString);
			_db = client.GetDatabase(config.Value.Database);
		}

		public IMongoCollection<Product> Products => _db.GetCollection<Product>("Products");
	}
}
