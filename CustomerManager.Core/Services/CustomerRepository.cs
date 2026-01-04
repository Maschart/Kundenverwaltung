using CustomerManager.Core.Data;
using CustomerManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Core.Services;

public class CustomerRepository
{
    private readonly DbContextOptions<AppDbContext> _options;

    public CustomerRepository(DbContextOptions<AppDbContext> options)
    {
        _options = options;
    }

    public async Task EnsureCreatedAsync()
    {
        await using var db = new AppDbContext(_options);
        await db.Database.EnsureCreatedAsync();
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        await using var db = new AppDbContext(_options);
        return await db.Customers
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        await using var db = new AppDbContext(_options);
        return await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Customer customer)
    {
        await using var db = new AppDbContext(_options);
        db.Customers.Add(customer);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        await using var db = new AppDbContext(_options);
        db.Customers.Update(customer);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var db = new AppDbContext(_options);
        var entity = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (entity == null) return;
        db.Customers.Remove(entity);
        await db.SaveChangesAsync();
    }
}