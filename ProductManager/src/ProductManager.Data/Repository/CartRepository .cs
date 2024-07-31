using Microsoft.EntityFrameworkCore;
using ProductManager.Data.Context;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Data.Repository;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(ManagerDbContext context) : base(context) { }

    public async Task AddProductToCart(Guid cartId, Guid productId, int quantity)
    {
        var cart = await GetById(cartId);
        if (cart != null)
        {
            var cartItem = new CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };

            Db.CartItems.Add(cartItem);
            await SaveChanges();
        }
    }

    public async Task CloseCart(Guid cartId)
    {
        var cart = await GetById(cartId);
        if (cart != null)
        {
            cart.CartHeader.IsClosed = true;
            await Update(cart);
        }

    }

    public async Task<Cart> GetCartById(Guid cartId)
    {
        return await Db.Carts.AsNoTracking()
                  .Include(c => c.CartHeader) 
                  .Include(c => c.CartItems)
                  .ThenInclude(ci => ci.Product)
                  .FirstOrDefaultAsync(c => c.Id == cartId);
    }

    public async Task<IEnumerable<Cart>> ListCarts()
    {
        return await Db.Carts.AsNoTracking()
               .Include(c => c.CartItems)
               .ThenInclude(ci => ci.Product)
               .OrderBy(c => c.Id)
               .ToListAsync();
    }

    public async Task RemoveProductFromCart(Guid cartId, Guid productId)
    {
        var cartItem = await Db.CartItems
         .Where(c => c.CartId == cartId && c.ProductId == productId)
         .FirstOrDefaultAsync();

        if (cartItem != null)
        {
            Db.CartItems.Remove(cartItem);
            await SaveChanges();
        }
    }

    public async Task Remove(Guid id)
    {
        var existingCart = await GetById(id);
        if (existingCart != null)
        {
            Db.Carts.Remove(existingCart);
            await SaveChanges();
        }
    }

    public async Task AddCartItem(CartItem cartItem)
    {
        await Db.CartItems.AddAsync(cartItem);
        await SaveChanges();
    }
}
