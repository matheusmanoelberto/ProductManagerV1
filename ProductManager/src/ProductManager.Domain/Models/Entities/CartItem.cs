namespace ProductManager.Domain.Models.Entities;

public class CartItem : Entity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid CartId { get; set; }
    public Product Product { get; set; }
}
