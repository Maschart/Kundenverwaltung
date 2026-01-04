using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Core.Data;

public static class DbFactory
{
    public static DbContextOptions<AppDbContext> CreateOptions(string dbPath)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlite($"Data Source={dbPath}");
        return builder.Options;
    }
}