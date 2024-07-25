using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces;

public interface IProductService
{
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Guid id);
}
