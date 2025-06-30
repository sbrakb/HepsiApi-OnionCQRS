using HepsiApi.Domain.Common;

namespace HepsiApi.Domain.Entities;

public class Brand : EntityBase
{
  public Brand()
  {

  }
  public Brand(string name)
  {
    Name = name;
  }
  // public Brand(int parentId, string name, int priorty)
  // {
  //   Name = name;
  // }
  public string Name { get; set; }

  public ICollection<Product> Products { get; set; }
}