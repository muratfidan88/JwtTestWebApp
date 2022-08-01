using JwtTestWebApp.ProductApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtTestWebApp.ProductApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price).HasPrecision(18, 3);
            builder.HasData(new Product { Id = 1, Name = "Telefon", Description = "Samsung", Price = 15.5m, Stock = 10 });
            builder.HasData(new Product { Id = 2, Name = "Tablet", Description = "Ipad", Price = 17.5m, Stock = 53 });
            builder.HasData(new Product { Id = 3, Name = "Mouse", Description = "Everest", Price = 1.3m, Stock = 67 });
            builder.HasData(new Product { Id = 4, Name = "Klavye", Description = "Gaming", Price = 1.7m, Stock = 89 });
            builder.HasData(new Product { Id = 5, Name = "Speaker", Description = "BO", Price = 2.5m, Stock = 111 });
            builder.HasData(new Product { Id = 6, Name = "Ekran Kartı", Description = "GeForce", Price = 15.8m, Stock = 110 });
            builder.HasData(new Product { Id = 7, Name = "Mouse Pad", Description = "Gaming", Price = 0.5m, Stock = 8 });
            builder.HasData(new Product { Id = 8, Name = "Kulaklık", Description = "Marshall", Price = 1.75m, Stock = 19 });
            builder.HasData(new Product { Id = 9, Name = "Telefon Kılıfı", Description = "Çin Malı", Price = 0.83m, Stock = 1 });
            builder.HasData(new Product { Id = 10, Name = "İşlemci", Description = "Intel", Price = 12.11m, Stock = 34 });
        }
    }
}
