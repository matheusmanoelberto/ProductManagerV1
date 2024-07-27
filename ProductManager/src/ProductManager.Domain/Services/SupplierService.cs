using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
using ProductManager.Domain.Models.Validations;

namespace ProductManager.Domain.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository,
                               INotifier notifier) : base(notifier)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)
                || !PerformValidation(new AddressValidation(), supplier.Address)) return;

            if(_supplierRepository.Get(s => s.Document == supplier.Document).Result.Any())
            {
                Notify("Já existe um fornecedor com este documento informado");
                return;
            }

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)) return;

            if (_supplierRepository.Get(s => s.Document == supplier.Document && s.Id != supplier.Id).Result.Any())
            {
                Notify("Já existe um fornecedor com este documento informado");
            }
            
            await _supplierRepository.Update(supplier);    
        }

        public async Task Remove(Guid supplierId)
        {
            var supplier = await _supplierRepository.GetSupplierProductsAddress(supplierId);

            if (supplier == null)
            {
                Notify("Fornecedor não exite!");
                return;
            }

            if (supplier.Products.Any())
            {
                Notify("O fornecedor possui produtos cadastrados!");
                return;
            }

            var address = await _supplierRepository.GetAddressbySupplier(supplierId);

            if(address != null)
            {
                await _supplierRepository.RemoveAddressSupplier(address);
            }

            await _supplierRepository.Remove(supplierId);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }

        void IDisposable.Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}