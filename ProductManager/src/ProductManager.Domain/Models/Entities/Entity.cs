using ProductManager.Domain.Enums;

namespace ProductManager.Domain.Models.Entities;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
}