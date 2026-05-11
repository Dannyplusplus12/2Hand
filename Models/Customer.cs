namespace _2Hand.Models;

public class Customer
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Phone { get; set; }
    public string? Address { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
