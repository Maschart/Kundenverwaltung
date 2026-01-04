using CustomerManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Core.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Name);
    }
}