using Bogus;
using HepsiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiApi.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {

    Faker faker = new("tr");

    Product product1 = new()
    {
      Id = 1,
      Title = "Gaming Laptop",
      Description = "High performance gaming laptop with RTX graphics",
      BrandId = 1,
      Discount = 5,
      Price = 7500,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    Product product2 = new()
    {
      Id = 2,
      Title = "Smart TV",
      Description = "4K Ultra HD Smart Television",
      BrandId = 3,
      Discount = 7,
      Price = 8500,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };


    builder.HasData(product1, product2);
  }
}
