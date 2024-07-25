using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductBySupplier(Guid supplierId);
        Task<Product> GetProductBySupplier();
        Task<Product> getProductSupplier(Guid id);
    }
}
