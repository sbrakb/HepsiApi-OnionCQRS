
using Microsoft.AspNetCore.Identity;

namespace HepsiApi.Domain.Entities;

public class User : IdentityUser<Guid>
{
  public string FullName { get; set; }
  public string? RefreshToken { get; set; }
  public DateTime? RefreshTokenExpireTime { get; set; }
}

public class Role : IdentityRole<Guid>
{

}