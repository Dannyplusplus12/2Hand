namespace _2Hand.Models;

public class TransactionItem
{
    public int Id { get; set; }
    public int TransactionId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Transaction? Transaction { get; set; }
    public Product? Product { get; set; }
}
