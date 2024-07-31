using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.ViewModels;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
using System.Net;

namespace ProductManager.Api.Controllers
{
    [Route("api/cart")]
    public class CartController : MainController
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartRepository cartRepository,
                              ICartService cartService,
                              IMapper mapper,
                              INotifier notifier) : base(notifier)
        {
            _cartRepository = cartRepository;
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CartViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CartViewModel>>(await _cartRepository.ListCarts());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CartViewModel>> GetById(Guid id)
        {
            var cartViewModel = await GetCart(id);

            if (cartViewModel == null) return NotFound();

            return cartViewModel;
        }

        [HttpGet("details/{id:guid}")]
        public async Task<CartViewModel> GetCart(Guid id)
        {
            return _mapper.Map<CartViewModel>(await _cartRepository.GetCartById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CartViewModel>> CreateCart()
        {
            var newCart = await _cartService.CreateCart();

            var cartViewModel = _mapper.Map<CartViewModel>(newCart);

            return CustomResponse(HttpStatusCode.Created, cartViewModel);          
        }

        [HttpPost("{cartId}/products")]
        public async Task<ActionResult> AddProductToCart(Guid cartId, CartItemViewModel cartItemViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (cartId != cartItemViewModel.CartId) return BadRequest();

            await _cartService.AddProductToCart(cartId, cartItemViewModel.ProductId, cartItemViewModel.Quantity);

            return CustomResponse(HttpStatusCode.Created, cartItemViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CartViewModel>> Update(Guid id, CartViewModel cartViewModel)
        {
            if (id != cartViewModel.Id)
            {
                NotifyError("Os IDs informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cart = _mapper.Map<Cart>(cartViewModel);
            await _cartService.Update(cart);

            return CustomResponse(HttpStatusCode.NoContent);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CartViewModel>> Delete(Guid id)
        {
            var cartViewModel = await GetCart(id);

            if (cartViewModel == null) return NotFound();

            await _cartService.Remove(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{cartId}/products/{productId}")]
        public async Task<ActionResult> RemoveProductFromCart(Guid cartId, Guid productId)
        {
            await _cartService.RemoveProductFromCart(cartId, productId);

            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}