﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Data;

#nullable disable

namespace ProductService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230626145952_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductService.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Name = "Fantastic Rubber Car",
                            Price = 56m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Intelligent Concrete Keyboard",
                            Price = 50m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Awesome Plastic Salad",
                            Price = 54m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Intelligent Fresh Bike",
                            Price = 55m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Awesome Soft Chips",
                            Price = 55m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Practical Frozen Cheese",
                            Price = 56m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Handcrafted Frozen Bacon",
                            Price = 54m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fantastic Fresh Computer",
                            Price = 49m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Ergonomic Plastic Mouse",
                            Price = 57m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Small Concrete Hat",
                            Price = 57m
                        },
                        new
                        {
                            Id = 11,
                            Name = "Ergonomic Soft Chicken",
                            Price = 57m
                        },
                        new
                        {
                            Id = 12,
                            Name = "Small Soft Bike",
                            Price = 51m
                        },
                        new
                        {
                            Id = 13,
                            Name = "Sleek Granite Mouse",
                            Price = 49m
                        },
                        new
                        {
                            Id = 14,
                            Name = "Generic Rubber Table",
                            Price = 52m
                        },
                        new
                        {
                            Id = 15,
                            Name = "Licensed Wooden Keyboard",
                            Price = 50m
                        },
                        new
                        {
                            Id = 16,
                            Name = "Practical Cotton Pizza",
                            Price = 55m
                        },
                        new
                        {
                            Id = 17,
                            Name = "Gorgeous Soft Soap",
                            Price = 56m
                        },
                        new
                        {
                            Id = 18,
                            Name = "Handcrafted Wooden Tuna",
                            Price = 50m
                        },
                        new
                        {
                            Id = 19,
                            Name = "Gorgeous Steel Soap",
                            Price = 54m
                        },
                        new
                        {
                            Id = 20,
                            Name = "Gorgeous Metal Pizza",
                            Price = 56m
                        },
                        new
                        {
                            Id = 21,
                            Name = "Handmade Granite Mouse",
                            Price = 57m
                        },
                        new
                        {
                            Id = 22,
                            Name = "Handcrafted Frozen Shoes",
                            Price = 52m
                        },
                        new
                        {
                            Id = 23,
                            Name = "Unbranded Metal Gloves",
                            Price = 56m
                        },
                        new
                        {
                            Id = 24,
                            Name = "Ergonomic Plastic Hat",
                            Price = 54m
                        },
                        new
                        {
                            Id = 25,
                            Name = "Unbranded Frozen Pizza",
                            Price = 50m
                        },
                        new
                        {
                            Id = 26,
                            Name = "Rustic Plastic Tuna",
                            Price = 51m
                        },
                        new
                        {
                            Id = 27,
                            Name = "Licensed Fresh Salad",
                            Price = 53m
                        },
                        new
                        {
                            Id = 28,
                            Name = "Small Soft Bike",
                            Price = 49m
                        },
                        new
                        {
                            Id = 29,
                            Name = "Incredible Concrete Hat",
                            Price = 57m
                        },
                        new
                        {
                            Id = 30,
                            Name = "Gorgeous Fresh Car",
                            Price = 50m
                        },
                        new
                        {
                            Id = 31,
                            Name = "Incredible Wooden Chips",
                            Price = 57m
                        },
                        new
                        {
                            Id = 32,
                            Name = "Refined Soft Mouse",
                            Price = 57m
                        },
                        new
                        {
                            Id = 33,
                            Name = "Sleek Frozen Cheese",
                            Price = 51m
                        },
                        new
                        {
                            Id = 34,
                            Name = "Licensed Metal Fish",
                            Price = 51m
                        },
                        new
                        {
                            Id = 35,
                            Name = "Refined Soft Keyboard",
                            Price = 55m
                        },
                        new
                        {
                            Id = 36,
                            Name = "Small Fresh Table",
                            Price = 49m
                        },
                        new
                        {
                            Id = 37,
                            Name = "Sleek Wooden Towels",
                            Price = 56m
                        },
                        new
                        {
                            Id = 38,
                            Name = "Licensed Rubber Table",
                            Price = 50m
                        },
                        new
                        {
                            Id = 39,
                            Name = "Refined Rubber Salad",
                            Price = 57m
                        },
                        new
                        {
                            Id = 40,
                            Name = "Fantastic Metal Towels",
                            Price = 57m
                        },
                        new
                        {
                            Id = 41,
                            Name = "Handcrafted Frozen Car",
                            Price = 52m
                        },
                        new
                        {
                            Id = 42,
                            Name = "Tasty Frozen Gloves",
                            Price = 54m
                        },
                        new
                        {
                            Id = 43,
                            Name = "Sleek Wooden Car",
                            Price = 52m
                        },
                        new
                        {
                            Id = 44,
                            Name = "Handmade Plastic Ball",
                            Price = 52m
                        },
                        new
                        {
                            Id = 45,
                            Name = "Handmade Fresh Shoes",
                            Price = 54m
                        },
                        new
                        {
                            Id = 46,
                            Name = "Gorgeous Plastic Computer",
                            Price = 57m
                        },
                        new
                        {
                            Id = 47,
                            Name = "Awesome Soft Table",
                            Price = 50m
                        },
                        new
                        {
                            Id = 48,
                            Name = "Handmade Soft Chips",
                            Price = 50m
                        },
                        new
                        {
                            Id = 49,
                            Name = "Gorgeous Wooden Keyboard",
                            Price = 53m
                        },
                        new
                        {
                            Id = 50,
                            Name = "Refined Cotton Mouse",
                            Price = 53m
                        },
                        new
                        {
                            Id = 51,
                            Name = "Refined Fresh Gloves",
                            Price = 54m
                        },
                        new
                        {
                            Id = 52,
                            Name = "Sleek Frozen Bike",
                            Price = 53m
                        },
                        new
                        {
                            Id = 53,
                            Name = "Gorgeous Granite Ball",
                            Price = 53m
                        },
                        new
                        {
                            Id = 54,
                            Name = "Intelligent Fresh Cheese",
                            Price = 51m
                        },
                        new
                        {
                            Id = 55,
                            Name = "Refined Wooden Hat",
                            Price = 49m
                        },
                        new
                        {
                            Id = 56,
                            Name = "Sleek Steel Sausages",
                            Price = 55m
                        },
                        new
                        {
                            Id = 57,
                            Name = "Intelligent Fresh Keyboard",
                            Price = 54m
                        },
                        new
                        {
                            Id = 58,
                            Name = "Rustic Concrete Towels",
                            Price = 51m
                        },
                        new
                        {
                            Id = 59,
                            Name = "Handcrafted Frozen Cheese",
                            Price = 51m
                        },
                        new
                        {
                            Id = 60,
                            Name = "Small Granite Table",
                            Price = 53m
                        },
                        new
                        {
                            Id = 61,
                            Name = "Awesome Fresh Chips",
                            Price = 50m
                        },
                        new
                        {
                            Id = 62,
                            Name = "Practical Cotton Car",
                            Price = 51m
                        },
                        new
                        {
                            Id = 63,
                            Name = "Fantastic Soft Mouse",
                            Price = 54m
                        },
                        new
                        {
                            Id = 64,
                            Name = "Unbranded Frozen Computer",
                            Price = 56m
                        },
                        new
                        {
                            Id = 65,
                            Name = "Unbranded Rubber Shoes",
                            Price = 54m
                        },
                        new
                        {
                            Id = 66,
                            Name = "Refined Rubber Table",
                            Price = 56m
                        },
                        new
                        {
                            Id = 67,
                            Name = "Unbranded Frozen Sausages",
                            Price = 50m
                        },
                        new
                        {
                            Id = 68,
                            Name = "Ergonomic Cotton Ball",
                            Price = 51m
                        },
                        new
                        {
                            Id = 69,
                            Name = "Handcrafted Frozen Tuna",
                            Price = 54m
                        },
                        new
                        {
                            Id = 70,
                            Name = "Small Metal Gloves",
                            Price = 55m
                        },
                        new
                        {
                            Id = 71,
                            Name = "Licensed Soft Bike",
                            Price = 51m
                        },
                        new
                        {
                            Id = 72,
                            Name = "Small Fresh Shirt",
                            Price = 54m
                        },
                        new
                        {
                            Id = 73,
                            Name = "Refined Frozen Shoes",
                            Price = 52m
                        },
                        new
                        {
                            Id = 74,
                            Name = "Tasty Soft Fish",
                            Price = 57m
                        },
                        new
                        {
                            Id = 75,
                            Name = "Practical Fresh Gloves",
                            Price = 52m
                        },
                        new
                        {
                            Id = 76,
                            Name = "Practical Soft Gloves",
                            Price = 57m
                        },
                        new
                        {
                            Id = 77,
                            Name = "Sleek Soft Chips",
                            Price = 57m
                        },
                        new
                        {
                            Id = 78,
                            Name = "Incredible Granite Cheese",
                            Price = 50m
                        },
                        new
                        {
                            Id = 79,
                            Name = "Intelligent Metal Pizza",
                            Price = 54m
                        },
                        new
                        {
                            Id = 80,
                            Name = "Fantastic Steel Car",
                            Price = 50m
                        },
                        new
                        {
                            Id = 81,
                            Name = "Awesome Concrete Table",
                            Price = 49m
                        },
                        new
                        {
                            Id = 82,
                            Name = "Unbranded Soft Shirt",
                            Price = 57m
                        },
                        new
                        {
                            Id = 83,
                            Name = "Gorgeous Soft Mouse",
                            Price = 49m
                        },
                        new
                        {
                            Id = 84,
                            Name = "Fantastic Fresh Pants",
                            Price = 49m
                        },
                        new
                        {
                            Id = 85,
                            Name = "Sleek Concrete Bacon",
                            Price = 50m
                        },
                        new
                        {
                            Id = 86,
                            Name = "Unbranded Granite Pants",
                            Price = 51m
                        },
                        new
                        {
                            Id = 87,
                            Name = "Rustic Concrete Ball",
                            Price = 51m
                        },
                        new
                        {
                            Id = 88,
                            Name = "Unbranded Metal Hat",
                            Price = 51m
                        },
                        new
                        {
                            Id = 89,
                            Name = "Refined Plastic Salad",
                            Price = 49m
                        },
                        new
                        {
                            Id = 90,
                            Name = "Fantastic Wooden Car",
                            Price = 55m
                        },
                        new
                        {
                            Id = 91,
                            Name = "Fantastic Steel Chicken",
                            Price = 53m
                        },
                        new
                        {
                            Id = 92,
                            Name = "Incredible Rubber Bacon",
                            Price = 51m
                        },
                        new
                        {
                            Id = 93,
                            Name = "Incredible Fresh Soap",
                            Price = 49m
                        },
                        new
                        {
                            Id = 94,
                            Name = "Gorgeous Fresh Computer",
                            Price = 56m
                        },
                        new
                        {
                            Id = 95,
                            Name = "Unbranded Steel Chips",
                            Price = 54m
                        },
                        new
                        {
                            Id = 96,
                            Name = "Awesome Steel Chips",
                            Price = 54m
                        },
                        new
                        {
                            Id = 97,
                            Name = "Intelligent Fresh Gloves",
                            Price = 56m
                        },
                        new
                        {
                            Id = 98,
                            Name = "Unbranded Wooden Tuna",
                            Price = 51m
                        },
                        new
                        {
                            Id = 99,
                            Name = "Intelligent Steel Pizza",
                            Price = 56m
                        },
                        new
                        {
                            Id = 100,
                            Name = "Licensed Soft Chair",
                            Price = 53m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
