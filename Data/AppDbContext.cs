using Microsoft.EntityFrameworkCore;
using _2Hand.Models;

namespace _2Hand.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<TransactionItem> TransactionItems => Set<TransactionItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasIndex(c => c.Phone).IsUnique();
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Transaction>().Property(t => t.TotalAmount).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<TransactionItem>().Property(i => i.UnitPrice).HasColumnType("decimal(18,2)");
    }
}
