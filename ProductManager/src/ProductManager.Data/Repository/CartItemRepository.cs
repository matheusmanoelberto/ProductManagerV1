using Microsoft.EntityFrameworkCore;
using ProductManager.Data.Context;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Models.Entities;
using System.Threading.Tasks;

namespace ProductManager.Data.Repository
{
    public class CartItemRepository : Repository<Cart>, ICartItemRepository
    {
        public CartItemRepository(ManagerDbContext context) : base(context) { }


        public Task<CartItem> GetCartItemById(Guid cartItemId)
        {
            return Db.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId)
        {
            return await Db.CartItems
                .Where(c => c.Id == cartId)
                .ToListAsync();
        }

        public async Task AddCartItem(Guid cartId, Guid productId, int quantity)
        {
            var cartItem = new CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };

            await Db.CartItems.AddAsync(cartItem);
            await Db.SaveChangesAsync();
        }
    }
}
