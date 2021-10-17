using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProductService.Models;
using ProductService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _logger = logger;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository
            .Products
            .Find(p => true)
            .ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _productRepository
            .Products
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await _productRepository
            .Products
            .Find(filter)
            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _productRepository
            .Products
            .Find(filter)
            .ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            await _productRepository.Products.InsertOneAsync(product);
        }


        public async Task<bool> UpdateProduct(Product product)
        {
            var existing = await _productRepository
             .Products
             .Find(p => p.Id == product.Id)
             .FirstOrDefaultAsync();
            product.InternalId = existing.InternalId;

            var updateResult = await _productRepository.Products.ReplaceOneAsync(g => g.Id == product.Id, product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var deleteResult = await _productRepository
            .Products
            .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
