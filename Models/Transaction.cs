namespace _2Hand.Models;

public class Transaction
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public Customer? Customer { get; set; }
    public ICollection<TransactionItem> Items { get; set; } = new List<TransactionItem>();
}
