using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HepsiApi.Domain.Entities;

namespace HepsiApi.Application.Interfaces.Tokens;

public interface ITokenService
{
  Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
  string GenerateRefreshToken();
  ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
}