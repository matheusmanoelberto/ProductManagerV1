using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Models.Entities;
namespace ProductManager.Data.Mappings;

public class CartMapping : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.CartHeader)
            .WithOne()
            .HasForeignKey<Cart>(x => x.Id);

        builder.HasMany(x => x.CartItems)
            .WithOne()
            .HasForeignKey(x => x.CartId);

        builder.ToTable("Carts");
    }
}