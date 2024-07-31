using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Models.Entities;
namespace ProductManager.Domain.Services;

public class CartService : BaseService, ICartService
{
    private readonly ICartRepository _cartRepository;
    public CartService(ICartRepository cartRepository, INotifier notifier) : base(notifier)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Cart> CreateCart()
    {
        var cartId = Guid.NewGuid();
        var newCart = new Cart
        {
            Id = cartId,  
            CartHeader = new CartHeader
            {
                Id = Guid.NewGuid(), 
                IdCartItem = Guid.NewGuid().ToString(),
                IsClosed = false,
                CartId = cartId 
            },
            CartItems = new List<CartItem>(), 
            IsClosed = false
        };

        await _cartRepository.Add(newCart);
        await _cartRepository.SaveChanges();

        return newCart;
    }
    public async Task AddProductToCart(Guid cartId, Guid productId, int quantity)
    {
        var cart = await _cartRepository.GetCartById(cartId);
        if (cart != null)
        {
            if (cart.IsClosed)
            {
                throw new InvalidOperationException("Não é possível adicionar produtos a um carrinho fechado.");
            }          

            var cartItem = new CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };
                       
            await _cartRepository.AddCartItem(cartItem);
            await _cartRepository.SaveChanges();
        }
    }

    public async Task Update(Cart cart)
    {
        var existingCart = await _cartRepository.GetById(cart.Id);
        if (existingCart != null)
        {
            existingCart.CartItems = cart.CartItems;

            await _cartRepository.Update(existingCart);
        }
    }

    public async Task CloseCart(Guid cartId)
    {
        var cart = await _cartRepository.GetCartById(cartId);
        if (cart != null)
        {
            if (!cart.CartItems.Any())
            {
                throw new InvalidOperationException("Não é possível fechar um carrinho vazio.");
            }

            cart.IsClosed = true;
            await _cartRepository.Update(cart);
        }

    }

    public async Task RemoveProductFromCart(Guid cartId, Guid productId)
    {
        await _cartRepository.RemoveProductFromCart(cartId, productId);
    }

    public async Task Remove(Guid id)
    {
        await _cartRepository.Remove(id);
    }

    public void Dispose()
    {
        _cartRepository?.Dispose();
    }
}
