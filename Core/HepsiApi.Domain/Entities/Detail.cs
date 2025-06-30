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
  public int CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Category Category { get; set; }
}
