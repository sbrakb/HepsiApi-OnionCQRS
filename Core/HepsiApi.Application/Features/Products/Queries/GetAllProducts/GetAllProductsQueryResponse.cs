using HepsiApi.Application.DTOs;
using HepsiApi.Domain.Common;

namespace HepsiApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
  public string Title { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }
  public decimal Discount { get; set; }
  public BrandDto Brand { get; set; }
}