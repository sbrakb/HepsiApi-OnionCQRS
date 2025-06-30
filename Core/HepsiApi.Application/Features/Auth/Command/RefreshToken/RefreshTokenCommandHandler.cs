using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Auth.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.Tokens;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HepsiApi.Application.Features.Auth.RefreshToken;

public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ITokenService _tokenService;
  private readonly AuthRules _authRules;
  public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService, AuthRules authRules) : base(unitOfWork, mapper, httpContextAccessor)
  {
    _userManager = userManager;
    _tokenService = tokenService;
    _authRules = authRules;
  }
  public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
  {
    ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
    string email = principal.FindFirstValue(ClaimTypes.Email);

    User? user = await _userManager.FindByEmailAsync(email);
    IList<string> roles = await _userManager.GetRolesAsync(user);

    await _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpireTime);

    JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
    string newRefreshToken = _tokenService.GenerateRefreshToken();

    user.RefreshToken = newRefreshToken;
    await _userManager.UpdateAsync(user);

    return new()
    {
      AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
      RefreshToken = newRefreshToken,
    };
  }
}