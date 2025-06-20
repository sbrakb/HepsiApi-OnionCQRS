using HepsiApi.Domain.Common;

namespace HepsiApi.Domain.Entities;

public class Detail : EntityBase
{
  public Detail()
  {

  }
  public Detail(int categoryId, string name, string description)
  {
    CategoryId = categoryId;
    Title = name;
    Description = description;
  }
  public required int CategoryId { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public Category Category { get; set; }
}
