using Microsoft.EntityFrameworkCore;
using _2Hand.Data;
using _2Hand.Models;

namespace _2Hand.Services;

public class ProductService
{
    private readonly AppDbContext context;

    public ProductService(AppDbContext context)
    {
        this.context = context;
    }

    public Task<List<Product>> GetAllAsync() => context.Products.AsNoTracking().ToListAsync();

    public async Task<Product> AddAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Products.FindAsync(id);
        if (entity == null)
        {
            return;
        }

        context.Products.Remove(entity);
        await context.SaveChangesAsync();
    }
}
