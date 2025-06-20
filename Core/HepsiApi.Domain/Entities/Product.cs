using HepsiApi.Domain.Common;

namespace HepsiApi.Domain.Entities;

public class Product : EntityBase
{
  public Product()
  {

  }
  public Product(int categoryId, int brandId, string title, string description, decimal price, decimal discount)
  {
    CategoryId = categoryId;
    Title = title;
    BrandId = brandId;
    Description = description;
    Price = price;
    Discount = discount;
  }
  public required int CategoryId { get; set; }
  public required int BrandId { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required decimal Price { get; set; }
  public required decimal Discount { get; set; }
  // public required string ImagePath { get; set; }


  public ICollection<Category> Categories { get; set; }
  public Brand Brand { get; set; }
}