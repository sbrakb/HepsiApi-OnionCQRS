using HepsiApi.Domain.Common;

namespace HepsiApi.Domain.Entities;

public class Product : EntityBase
{
  public Product()
  {

  }
  public Product(int brandId, string title, string description, decimal price, decimal discount)
  {

    Title = title;
    BrandId = brandId;
    Description = description;
    Price = price;
    Discount = discount;
  }

  public int BrandId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }
  public decimal Discount { get; set; }
  // public required string ImagePath { get; set; }


  public ICollection<ProductCategory> ProductCategories { get; set; }
  public Brand Brand { get; set; }
}