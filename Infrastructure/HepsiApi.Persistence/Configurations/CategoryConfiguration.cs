using HepsiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiApi.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    Category parent1 = new()
    {
      Id = 1,
      Name = "Elektrik",
      Priorty = 1,
      ParentId = 0,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    Category parent2 = new()
    {
      Id = 2,
      Name = "Moda",
      Priorty = 2,
      ParentId = 0,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    Category category1 = new()
    {
      Id = 3,
      Name = "Bilgisayar",
      Priorty = 1,
      ParentId = 1,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    Category category2 = new()
    {
      Id = 4,
      Name = "Kadın",
      Priorty = 1,
      ParentId = 2,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    builder.HasData(parent1, parent2, category1, category2);
  }
}