using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
using ProductManager.Domain.Models.Validations;

namespace ProductManager.Domain.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)
                || !PerformValidation(new AddressValidation(), supplier.Address)) return;

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)) return;
            
            await _supplierRepository.Update(supplier);    
        }

        public async Task Remove(Guid id)
        {
            await _supplierRepository.Remove(id);
        }

        public Task Dispose()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}