using Bogus;
using HepsiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiApi.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
  public void Configure(EntityTypeBuilder<Detail> builder)
  {

    Detail detail1 = new()
    {
      Id = 1,
      Title = "Elektronik Detayları",
      Description = "Elektronik kategorisi için detay bilgileri",
      CategoryId = 1,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    Detail detail2 = new()
    {
      Id = 2,
      Title = "Bilgisayar Detayları",
      Description = "Bilgisayar kategorisi için detay bilgileri",
      CategoryId = 3,
      IsDeleted = true,
      CreatedDate = new DateTime(2024, 1, 1) // Sabit tarih
    };

    Detail detail3 = new()
    {
      Id = 3,
      Title = "Kadın Detayları",
      Description = "Kadın kategorisi için detay bilgileri",
      CategoryId = 4,
      CreatedDate = new DateTime(2024, 1, 1), // Sabit tarih
      IsDeleted = false
    };

    builder.HasData(detail1, detail2, detail3);
  }
}
