using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistance;

public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
{
    public OrderDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                               ?? "Host=localhost;Port=5432;Database=BmbPlatformDb;Username=postgres;Password=123";

        optionsBuilder.UseNpgsql(connectionString, npgsqlOptions =>
        {
            npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_OrderService");
        });

        return new OrderDbContext(optionsBuilder.Options);
    }
}
