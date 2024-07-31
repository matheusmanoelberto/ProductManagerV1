using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Services;

public interface ICartService
{
    Task AddProductToCart(Guid cartId, Guid productId, int quantity);
    Task RemoveProductFromCart(Guid cartId, Guid productId);
    Task CloseCart(Guid cartId);
    Task Remove(Guid id);
    Task Update(Cart cart);
}
