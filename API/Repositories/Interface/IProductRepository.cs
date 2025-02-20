using System;
using API.Entities;

namespace API.Repositories.Interface;

public interface IProductRepository
{
    Task<Product> CreateProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductById(int id);
    Task<Product?> UpdateProduct(Product product);
    Task<Product?> DeleteProductAsync(int id);
}
