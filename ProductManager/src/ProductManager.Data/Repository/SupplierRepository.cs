using Microsoft.EntityFrameworkCore;
using ProductManager.Data.Context;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Data.Repository;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ManagerDbContext context) : base(context) { }

    public async Task<Supplier> GetSupplierAddress(Guid id)
    {
        return await Db.Suppliers.AsNoTracking()
            .Include(c => c.Address)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Address> GetAddressbySupplier(Guid supplierId)
    {
        return await Db.Addresses.AsNoTracking()
            .FirstOrDefaultAsync(f => f.SupplierId == supplierId);
    }


    public async Task<Supplier> GetSupplierProductsAddress(Guid id)
    {
        return await Db.Suppliers.AsNoTracking()
             .Include(c => c.Products)
             .Include(c => c.Address)
             .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task RemoveAddressSupplier(Address address)
    {
        Db.Addresses.Remove(address);
        await SaveChanges();
    }
}
