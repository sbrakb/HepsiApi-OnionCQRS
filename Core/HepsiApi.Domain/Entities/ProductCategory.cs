using HepsiApi.Domain.Common;

namespace HepsiApi.Domain.Entities;


public class ProductCategory : IEntityBase
{
  public int ProductId { get; set; }
  public int CategoryId { get; set; }

  public Product Product { get; set; }
  public Category Category { get; set; }
}