using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces;

public interface ISupplierService :IDisposable
{
    Task Create(Supplier supplier);
    Task Update(Supplier supplier);
    Task Delete(Guid id);
}
