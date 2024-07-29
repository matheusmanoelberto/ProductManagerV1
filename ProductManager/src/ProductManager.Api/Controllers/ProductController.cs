using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.ViewModels;

namespace ProductManager.Api.Controllers
{
    [Route("api/supplier")]
    public class ProductController : MainController
    {
        public ProductController()
        {
            
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
        {

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Update(Guid id, ProductViewModel productViewModel)
        {

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
        {

        }

    }
}
