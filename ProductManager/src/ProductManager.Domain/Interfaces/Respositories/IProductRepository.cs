using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Respositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductBySupplier(Guid supplierId);
    Task<IEnumerable<Product>> GetProductSupplier();
    Task<Product> GetProductSupplier(Guid id);
}
