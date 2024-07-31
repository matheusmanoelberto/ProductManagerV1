namespace ProductManager.Domain.Models.Entities;

public class Cart : Entity
{
    public Guid CartHeaderId { get; set; }
    public CartHeader CartHeader { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
    public bool IsClosed { get; set; }
}
