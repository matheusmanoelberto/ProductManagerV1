using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Services;

public interface IProductService
{
    Task Add(Product product);
    Task Update(Product product);
    Task Remove(Guid id);
}
