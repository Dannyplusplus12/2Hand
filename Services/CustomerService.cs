using Microsoft.EntityFrameworkCore;
using _2Hand.Data;
using _2Hand.Models;

namespace _2Hand.Services;

public class CustomerService
{
    private readonly AppDbContext context;

    public CustomerService(AppDbContext context)
    {
        this.context = context;
    }

    public Task<List<Customer>> GetAllAsync() => context.Customers.AsNoTracking().ToListAsync();

    public Task<Customer?> FindByPhoneAsync(string phone)
        => context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Phone == phone);

    public async Task<Customer> AddAsync(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }
}
