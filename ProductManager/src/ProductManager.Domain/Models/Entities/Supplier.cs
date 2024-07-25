using ProductManager.Domain.Enums;

namespace ProductManager.Domain.Models.Entities;

public class Supplier : Entity
{
    public string? Name { get; set; }
    public string? Document { get; set; }
    public TypeSupplier TypeSupplier { get; set; }
    public bool Active { get; set; }
    public Address? Address { get; set; }
}
