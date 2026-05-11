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

    public async Task<DashboardSummary> GetDashboardSummaryAsync()
    {
        var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        var monthRevenue = await context.Transactions
            .AsNoTracking()
            .Where(t => t.CreatedAt >= startOfMonth)
            .SumAsync(t => (decimal?)t.TotalAmount) ?? 0;

        var totalStock = await context.Products.AsNoTracking().SumAsync(p => (int?)p.Quantity) ?? 0;
        var lowStockCount = await context.Products.AsNoTracking().CountAsync(p => p.Quantity <= 2);

        var recentTransactions = await context.Transactions
            .AsNoTracking()
            .Include(t => t.Customer)
            .OrderByDescending(t => t.CreatedAt)
            .Take(10)
            .Select(t => new RecentTransaction
            {
                Id = t.Id,
                CustomerId = t.CustomerId,
                CustomerName = t.Customer != null ? t.Customer.FullName : string.Empty,
                CustomerPhone = t.Customer != null ? t.Customer.Phone : string.Empty,
                TotalAmount = t.TotalAmount,
                CreatedAt = t.CreatedAt
            })
            .ToListAsync();

        return new DashboardSummary
        {
            MonthRevenue = monthRevenue,
            TotalStock = totalStock,
            LowStockCount = lowStockCount,
            RecentTransactions = recentTransactions
        };
    }
}
