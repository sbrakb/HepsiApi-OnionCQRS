using Bogus;
using HepsiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiApi.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
  public void Configure(EntityTypeBuilder<Brand> builder)
  {
    builder.Property(b => b.Name).HasMaxLength(256);

    builder.HasData(
        new Brand { Id = 1, Name = "Movies & Books", CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
        new Brand { Id = 2, Name = "Clothing", CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
        new Brand { Id = 3, Name = "Home", CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
    );
  }
}
