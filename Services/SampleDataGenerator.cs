using _2Hand.Models;

namespace _2Hand.Services;

public static class SampleDataGenerator
{
    private static readonly string[] ProductNames =
    [
        "Áo thun vintage",
        "Quần jeans",
        "Giày sneaker",
        "Túi xách",
        "Áo khoác",
        "Đầm hoa",
        "Nón lưỡi trai",
        "Đồng hồ",
        "Áo sơ mi",
        "Giày cao gót"
    ];

    private static readonly string[] CustomerNames =
    [
        "Nguyễn Minh",
        "Trần Anh",
        "Lê Hương",
        "Phạm Quân",
        "Hoàng Mai",
        "Đỗ Hạnh",
        "Bùi Long",
        "Vũ An",
        "Đặng Linh",
        "Phan Tú"
    ];

    public static List<Product> GenerateProducts(int count)
    {
        var random = new Random();
        var products = new List<Product>();

        for (var index = 0; index < count; index++)
        {
            var name = ProductNames[random.Next(ProductNames.Length)];
            products.Add(new Product
            {
                Id = index + 1,
                Name = name,
                Description = "Hàng 2hand chất lượng",
                Price = random.Next(5, 60) * 10000,
                Quantity = random.Next(1, 40),
                ImagePath = null
            });
        }

        return products;
    }

    public static List<Customer> GenerateCustomers(int count)
    {
        var random = new Random();
        var customers = new List<Customer>();

        for (var index = 0; index < count; index++)
        {
            var name = CustomerNames[random.Next(CustomerNames.Length)];
            customers.Add(new Customer
            {
                Id = index + 1,
                FullName = name,
                Phone = $"09{random.Next(10000000, 99999999)}",
                Address = "Hồ Chí Minh"
            });
        }

        return customers;
    }

    public static List<Transaction> GenerateTransactions(List<Customer> customers, List<Product> products, int count)
    {
        var random = new Random();
        var transactions = new List<Transaction>();

        for (var index = 0; index < count; index++)
        {
            var customer = customers[random.Next(customers.Count)];
            var itemCount = random.Next(1, 4);
            var items = new List<TransactionItem>();
            decimal total = 0;

            for (var itemIndex = 0; itemIndex < itemCount; itemIndex++)
            {
                var product = products[random.Next(products.Count)];
                var quantity = random.Next(1, 3);
                var unitPrice = product.Price;
                total += unitPrice * quantity;

                items.Add(new TransactionItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                });
            }

            transactions.Add(new Transaction
            {
                Id = index + 1,
                CustomerId = customer.Id,
                Customer = customer,
                CreatedAt = DateTime.Today.AddDays(-random.Next(0, 14)).AddHours(random.Next(8, 20)),
                TotalAmount = total,
                Items = items
            });
        }

        return transactions;
    }
}
