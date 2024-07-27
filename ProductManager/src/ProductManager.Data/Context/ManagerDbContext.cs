using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Data.Context;

public class ManagerDbContext : DbContext
{
    public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}