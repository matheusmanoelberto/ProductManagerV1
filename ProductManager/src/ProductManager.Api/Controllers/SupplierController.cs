using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.ViewModels;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
using System.Net;

namespace ProductManager.Api.Controllers;

[Route("api/supplier")]
public class SupplierController : MainController
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;
    public SupplierController(ISupplierRepository supplierRepository,
                              ISupplierService supplierService,
                              IMapper mapper,
                              INotifier notifier) : base(notifier)
    {
        _supplierRepository = supplierRepository;
        _supplierService = supplierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SupplierViewModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
    {
        var supplier = await GetSupplierProductsAddress(id);

        if (supplier == null) return NotFound();

        return supplier;
    }

    [HttpPost]
    public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _supplierService.Add(_mapper.Map<Supplier>(supplierViewModel));

        return CustomResponse(HttpStatusCode.Created, supplierViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
    {
        if (id != supplierViewModel.Id)
        {
            NotifyError("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(HttpStatusCode.NoContent);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _supplierService.Update(_mapper.Map<Supplier>(supplierViewModel));

        return CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
    {
        await _supplierService.Remove(id);

        return CustomResponse(HttpStatusCode.NoContent);
    }
    private async Task<SupplierViewModel> GetSupplierProductsAddress(Guid id)
    {
        return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductsAddress(id));
    }

}
