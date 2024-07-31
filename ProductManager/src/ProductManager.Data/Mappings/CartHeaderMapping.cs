using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Data.Mappings;

public class CartHeaderMapping : IEntityTypeConfiguration<CartHeader>
{
    public void Configure(EntityTypeBuilder<CartHeader> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdCartItem)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.IsClosed)
            .IsRequired();

        builder.ToTable("CartHeaders");
    }
}
