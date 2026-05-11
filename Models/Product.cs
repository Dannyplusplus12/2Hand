namespace _2Hand.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? ImagePath { get; set; }
    public ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
