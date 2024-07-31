using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Respositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart> GetCartById(Guid cartId);
    Task<IEnumerable<Cart>> ListCarts();
    Task AddProductToCart(Guid cartId, Guid productId, int quantity);
    Task RemoveProductFromCart(Guid cartId, Guid productId);
    Task CloseCart(Guid cartId);
    Task AddCartItem(CartItem cartItem);
}
