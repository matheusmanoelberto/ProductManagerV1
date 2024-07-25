namespace ProductManager.Domain.Models.Entities;

public class Address : Entity
{
    public string? Logradouro { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public string? ZipCode { get; set; }
    public string? District { get; set; }
    public string? Cyte { get; set; }
    public string? State { get; set; }

}