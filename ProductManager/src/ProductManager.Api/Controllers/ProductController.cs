using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.ViewModels;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
using System.Net;

namespace ProductManager.Api.Controllers;

[Route("api/product")]
public class ProductController : MainController
{
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductRepository productRepository,
                            IProductService productService,
                            IMapper mapper,
                            INotifier notifier) : base(notifier) 
    {
        _productRepository = productRepository;
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductSupplier());            
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
    {
        var productViewModel = await GetProduct(id);

        if (productViewModel == null) return NotFound();

        return productViewModel;
    }
    [HttpGet("paged")]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetPaged(int pageNumber, int pageSize)
    {
        var pagedProducts = await _productRepository.GetPaged(pageNumber, pageSize);
        var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(pagedProducts);
        return Ok(mappedProducts);
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _productService.Add(_mapper.Map<Product>(productViewModel));

        return CustomResponse(System.Net.HttpStatusCode.Created, productViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Update(Guid id, ProductViewModel productViewModel)
    {
        if (id != productViewModel.Id)
        {
            NotifyError("Os ids informados não são iguais!");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var productUpdate = await GetProduct(id);

        productUpdate.SupplierId = productViewModel.SupplierId;
        productUpdate.Name = productViewModel.Name;
        productUpdate.Description = productViewModel.Description;
        productUpdate.Value = productViewModel.Value;
        productUpdate.Active = productViewModel.Active;

        await _productService.Update(_mapper.Map<Product>(productUpdate));

        return CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
    {
        var product = await GetProduct(id);

        if (product != null) return NotFound();
        return CustomResponse(HttpStatusCode.NoContent);
    }

    private async Task<ProductViewModel> GetProduct(Guid id)
    {
        return _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));
    }

}
