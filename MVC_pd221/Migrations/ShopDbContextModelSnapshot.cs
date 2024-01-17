﻿// <auto-generated />
using MVC_pd221.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_pd221.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_pd221.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Electronics",
                            Discount = 10,
                            ImageUrl = "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png",
                            InStock = false,
                            Name = "iPhone X",
                            Price = 650m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Sport",
                            Discount = 0,
                            ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_727192-CBT53879999753_022023-V.jpg",
                            InStock = false,
                            Name = "PowerBall",
                            Price = 45.5m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Fashion",
                            Discount = 15,
                            ImageUrl = "https://www.seekpng.com/png/detail/316-3168852_nike-air-logo-t-shirt-nike-t-shirt.png",
                            InStock = true,
                            Name = "Nike T-Shirt",
                            Price = 189m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Electronics",
                            Discount = 5,
                            ImageUrl = "https://sota.kh.ua/image/cache/data/Samsung-2/samsung-s23-s23plus-blk-01-700x700.webp",
                            InStock = true,
                            Name = "Samsung S23",
                            Price = 1200m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Toys & Hobbies",
                            Discount = 0,
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0046/1163/7320/products/69ee701e-e806-4c4d-b804-d53dc1f0e11a_grande.jpg",
                            InStock = false,
                            Name = "Air Ball",
                            Price = 50m
                        },
                        new
                        {
                            Id = 6,
                            Category = "Electronics",
                            Discount = 10,
                            ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp",
                            InStock = true,
                            Name = "MacBook Pro 2019",
                            Price = 1200m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
