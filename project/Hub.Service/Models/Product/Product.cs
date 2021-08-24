using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hub.Service.Models
{
	public class Product
	{
		[BsonId]
		public ObjectId InternalId { get; set; }
		public long Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
	}
}
