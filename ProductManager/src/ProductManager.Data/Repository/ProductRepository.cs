using Microsoft.EntityFrameworkCore;
using ProductManager.Data.Context;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Data.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ManagerDbContext context) : base(context) { }

    public async Task<Product> GetProductSupplier(Guid id)
    {
        return await Db.Products.AsNoTracking()
            .Include(s => s.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<IEnumerable<Product>> GetProductSupplier()
    {
        return await Db.Products.AsNoTracking()
           .Include(s => s.Supplier)
           .OrderBy(p => p.Name)
           .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetProductBySupplier(Guid supplierId)
    {
        return await Get(p => p.SupplierId == supplierId);
    }


}
