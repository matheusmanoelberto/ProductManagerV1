using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.ViewModels;

namespace ProductManager.Api.Controllers
{
    [Route("api/supplier")]
    public class SupplierController : MainController
    {
        public SupplierController()
        {
            
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierViewModel>> GetAll()
        {

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
        {

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
        {

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
        {

        }

    }
}
