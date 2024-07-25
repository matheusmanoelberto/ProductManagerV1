using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Respositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductBySupplier(Guid supplierId);
    Task<Product> GetProductBySupplier();
    Task<Product> GetProductSupplier(Guid id);
}
