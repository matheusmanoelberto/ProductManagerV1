using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.ViewModels;

namespace ProductManager.Api.Controllers
{
    [Route("api/supplier")]
    public class AddressController : MainController
    {
        public AddressController()
        {
            
        }

        [HttpGet]
        public async Task<IEnumerable<AddressViewModel>> GetAll()
        {

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> GetById(Guid id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<AddressViewModel>> Add(AddressViewModel addressViewModel)
        {

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> Update(Guid id, AddressViewModel addressViewModel)
        {

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> Delete(Guid id)
        {

        }

    }
}
