using CustomerManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Core.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .IsRequired();

        // NUR die Kombination ist eindeutig
        modelBuilder.Entity<Customer>()
            .HasIndex(c => new { c.Name, c.Email, c.Phone })
            .IsUnique();
    }



}