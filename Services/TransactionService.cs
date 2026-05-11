using Microsoft.EntityFrameworkCore;
using _2Hand.Data;
using _2Hand.Models;

namespace _2Hand.Services;

public class TransactionService
{
    private readonly AppDbContext context;

    public TransactionService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Transaction> CheckoutAsync(int customerId, List<(int productId, int quantity)> items)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        var customer = await context.Customers.FindAsync(customerId);
        if (customer == null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        var productIds = items.Select(i => i.productId).Distinct().ToList();
        var products = await context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

        var transactionEntity = new Transaction
        {
            CustomerId = customerId,
            CreatedAt = DateTime.UtcNow,
            Items = new List<TransactionItem>()
        };

        decimal total = 0;
        foreach (var item in items)
        {
            var product = products.First(p => p.Id == item.productId);
            if (product.Quantity < item.quantity)
            {
                throw new InvalidOperationException("Insufficient stock");
            }

            product.Quantity -= item.quantity;
            var lineTotal = product.Price * item.quantity;
            total += lineTotal;

            transactionEntity.Items.Add(new TransactionItem
            {
                ProductId = product.Id,
                Quantity = item.quantity,
                UnitPrice = product.Price
            });
        }

        transactionEntity.TotalAmount = total;
        context.Transactions.Add(transactionEntity);
        await context.SaveChangesAsync();
        await transaction.CommitAsync();

        return transactionEntity;
    }

    public async Task<List<Transaction>> GetHistoryAsync(int customerId)
    {
        return await context.Transactions
            .AsNoTracking()
            .Include(t => t.Items)
            .ThenInclude(i => i.Product)
            .Where(t => t.CustomerId == customerId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }
}
