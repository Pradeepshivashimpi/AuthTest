using System;
using API.Data;
using API.DTO;
using API.Entities;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Product?> DeleteProductAsync(int id)
    {
        var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
        if (existingProduct is null)
        {
            return null;
        }
        dbContext.Products.Remove(existingProduct);
        await dbContext.SaveChangesAsync();
        return existingProduct;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await dbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.ID == product.ID);
        if (existingProduct != null)
        {
            dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        return null;
    }
}
