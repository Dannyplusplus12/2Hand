using Microsoft.EntityFrameworkCore;

namespace _2Hand.Data;

public static class DbContextFactory
{
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=2hand_data.db")
            .Options;

        return new AppDbContext(options);
    }
}
