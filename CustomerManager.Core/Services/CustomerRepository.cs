using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerManager.Core.Data;
using CustomerManager.Core.Models;


namespace CustomerManager.Core.Services;

public class CustomerRepository
{
    private readonly DbContextOptions<AppDbContext> _options;

    public async Task<bool> ExistsDuplicateAsync(int? excludeId, string name, string? email, string? phone)
    {
        // Nur prüfen, wenn alle drei Werte vorhanden sind
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(phone))
            return false;

        await using var db = new AppDbContext(_options);

        var nameNorm = name.Trim();
        var emailNorm = email.Trim().ToLower();
        var phoneNorm = phone.Trim();

        return await db.Customers.AnyAsync(c =>
            (excludeId == null || c.Id != excludeId.Value) &&
            c.Name == nameNorm &&
            c.Email != null && c.Email.ToLower() == emailNorm &&
            c.Phone == phoneNorm
        );
    }




    

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