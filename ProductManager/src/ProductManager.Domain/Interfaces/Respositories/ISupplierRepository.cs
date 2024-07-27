using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Respositories;

public interface ISupplierRepository :IRepository<Supplier>
{
    Task<Supplier> GetSupplierAddress(Guid id);
    Task<Supplier> GetSupplierProductsAddress(Guid id);
    Task<Address> GetAddressbySupplier(Guid supplierId);
    Task RemoveAddressSupplier(Address address);
}
