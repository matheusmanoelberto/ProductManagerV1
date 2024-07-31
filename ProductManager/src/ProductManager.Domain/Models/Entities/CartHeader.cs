namespace ProductManager.Domain.Models.Entities;

public class CartHeader : Entity
{
    public string? IdCartItem { get; set; }
    public bool IsClosed { get; set; }
    public Guid CartId { get; set; }
}
