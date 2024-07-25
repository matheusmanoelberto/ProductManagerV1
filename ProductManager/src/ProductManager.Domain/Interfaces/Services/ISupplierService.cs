using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Services;

public interface ISupplierService :IDisposable
{
    Task Add(Supplier supplier);
    Task Update(Supplier supplier);
    Task Remove(Guid id);
    Task Dispose();
}
