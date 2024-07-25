using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces;

public interface ISupplierRepository :IRepository<Supplier>
{
    Task<Supplier> GetSupplierAddress(Guid id);
    Task<Supplier> GetSupplierProductsAddress(Guid id);
    Task<Supplier> GetAddressbySupplier(Guid );
}
