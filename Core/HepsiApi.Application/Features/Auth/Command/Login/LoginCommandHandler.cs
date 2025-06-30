using System.IdentityModel.Tokens.Jwt;
using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Auth.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.Tokens;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace HepsiApi.Application.Features.Auth.Command.Login;


public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ITokenService _tokenService;
  private readonly IConfiguration _configuration;
  private readonly AuthRules _authRules;

  public LoginCommandHandler(IConfiguration configuration, AuthRules authRules, UserManager<User> userManager, ITokenService tokenService, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
  {
    _userManager = userManager;
    _tokenService = tokenService;
    _configuration = configuration;
    _authRules = authRules;
  }
  public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
  {
    User user = await _userManager.FindByEmailAsync(request.Email);
    bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
    await _authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

    IList<string> roles = await _userManager.GetRolesAsync(user);

    JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
    string refreshToken = _tokenService.GenerateRefreshToken();

    _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

    user.RefreshToken = refreshToken;
    user.RefreshTokenExpireTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

    await _userManager.UpdateAsync(user);
    await _userManager.UpdateSecurityStampAsync(user);

    string _token = new JwtSecurityTokenHandler().WriteToken(token);

    await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

    return new()
    {
      Token = _token,
      RefreshToken = refreshToken,
      Expiration = token.ValidTo
    };
  }
}
