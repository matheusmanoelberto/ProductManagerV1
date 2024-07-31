using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Interfaces.Respositories;

public interface ICartItemRepository
{
    Task<CartItem> GetCartItemById(Guid cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId);
}
