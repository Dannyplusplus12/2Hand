namespace _2Hand.Models;

public class DashboardSummary
{
    public decimal MonthRevenue { get; set; }
    public int TotalStock { get; set; }
    public int LowStockCount { get; set; }
    public List<RecentTransaction> RecentTransactions { get; set; } = new();
}

public class RecentTransaction
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}
