using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProductService.Models
{
	public class Product
	{
		[BsonId]
		public ObjectId InternalId { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
	}
}
