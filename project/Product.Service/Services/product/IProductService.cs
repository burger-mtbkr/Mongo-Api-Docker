﻿using System;
﻿using ProductService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Services
{
	public interface IProductService
	{
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
        Task CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
