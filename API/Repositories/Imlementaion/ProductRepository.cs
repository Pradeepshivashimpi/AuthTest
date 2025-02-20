using System;
using API.Data;
using API.DTO;
using API.Entities;
using API.Repositories.Interface;

namespace API.Repositories.Imlementaion;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDataContext dbContext;

    public ProductRepository(ApplicationDataContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Product> CreateProductAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public Task<Product?> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
