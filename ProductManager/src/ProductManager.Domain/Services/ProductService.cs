using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
using ProductManager.Domain.Models.Validations;

namespace ProductManager.Domain.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Add(Product product)
    {
        if(!PerformValidation(new ProductValidation(), product)) return;

       await _productRepository.Add(product);
    }

    public async Task Update(Product product)
    {
        if (!PerformValidation(new ProductValidation(), product)) return;

        await _productRepository.Update(product);
    }
    public async Task Remove(Guid id)
    {
        await _productRepository.Remove(id);
    }

    public void Dispose()
    {
      _productRepository?.Dispose();
    }
}