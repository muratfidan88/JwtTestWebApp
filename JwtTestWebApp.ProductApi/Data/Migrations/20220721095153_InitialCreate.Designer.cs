﻿// <auto-generated />
using JwtTestWebApp.ProductApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JwtTestWebApp.ProductApi.Data.Migrations
{
    [DbContext(typeof(JwtTestProductContext))]
    [Migration("20220721095153_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JwtTestWebApp.ProductApi.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Samsung",
                            Name = "Telefon",
                            Price = 15.5m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ipad",
                            Name = "Tablet",
                            Price = 17.5m,
                            Stock = 53
                        },
                        new
                        {
                            Id = 3,
                            Description = "Everest",
                            Name = "Mouse",
                            Price = 1.3m,
                            Stock = 67
                        },
                        new
                        {
                            Id = 4,
                            Description = "Gaming",
                            Name = "Klavye",
                            Price = 1.7m,
                            Stock = 89
                        },
                        new
                        {
                            Id = 5,
                            Description = "BO",
                            Name = "Speaker",
                            Price = 2.5m,
                            Stock = 111
                        },
                        new
                        {
                            Id = 6,
                            Description = "GeForce",
                            Name = "Ekran Kartı",
                            Price = 15.8m,
                            Stock = 110
                        },
                        new
                        {
                            Id = 7,
                            Description = "Gaming",
                            Name = "Mouse Pad",
                            Price = 0.5m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 8,
                            Description = "Marshall",
                            Name = "Kulaklık",
                            Price = 1.75m,
                            Stock = 19
                        },
                        new
                        {
                            Id = 9,
                            Description = "Çin Malı",
                            Name = "Telefon Kılıfı",
                            Price = 0.83m,
                            Stock = 1
                        },
                        new
                        {
                            Id = 10,
                            Description = "Intel",
                            Name = "İşlemci",
                            Price = 12.11m,
                            Stock = 34
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
