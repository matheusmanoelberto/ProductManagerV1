﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductManager.Data.Context;

#nullable disable

namespace ProductManager.Data.Migrations
{
    [DbContext(typeof(ManagerDbContext))]
    partial class ManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uuid");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("addresses", (string)null);
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartHeaderId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.CartHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<string>("IdCartItem")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.ToTable("CartHeaders", (string)null);
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TypeSupplier")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Address", b =>
                {
                    b.HasOne("ProductManager.Domain.Models.Entities.Supplier", "Supplier")
                        .WithOne("Address")
                        .HasForeignKey("ProductManager.Domain.Models.Entities.Address", "SupplierId")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.CartHeader", b =>
                {
                    b.HasOne("ProductManager.Domain.Models.Entities.Cart", null)
                        .WithOne("CartHeader")
                        .HasForeignKey("ProductManager.Domain.Models.Entities.CartHeader", "CartId")
                        .IsRequired();
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.CartItem", b =>
                {
                    b.HasOne("ProductManager.Domain.Models.Entities.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .IsRequired();

                    b.HasOne("ProductManager.Domain.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Product", b =>
                {
                    b.HasOne("ProductManager.Domain.Models.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Cart", b =>
                {
                    b.Navigation("CartHeader")
                        .IsRequired();

                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ProductManager.Domain.Models.Entities.Supplier", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
