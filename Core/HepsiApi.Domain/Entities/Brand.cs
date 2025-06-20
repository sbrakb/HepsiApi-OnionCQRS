using HepsiApi.Domain.Common;

namespace HepsiApi.Domain.Entities;

public class Brand : EntityBase
{
  public Brand()
  {

  }
  public Brand(int parentId, string name, int priorty)
  {
    Name = name;
  }
  public required string Name { get; set; }
}