using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options) { }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(p => p.Id);
        modelBuilder.Entity<Order>().Property(p => p.ProductId).IsRequired();
        modelBuilder.Entity<Order>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<Order>().Property(p => p.Total).IsRequired();
        modelBuilder.Entity<Order>().Property(p => p.ClientId).IsRequired();
        modelBuilder.Entity<Order>().Property(p => p.OrderDate).IsRequired();
    }
}