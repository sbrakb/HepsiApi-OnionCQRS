using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Auth.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HepsiApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
  private readonly UserManager<User> _userManager;
  private readonly AuthRules _authRules;
  public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
  {
    _userManager = userManager;
    _authRules = authRules;
  }

  public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
  {
    User user = await _userManager.FindByEmailAsync(request.Email);
    await _authRules.EmailAddressShouldBeValid(user);

    user.RefreshToken = null;
    await _userManager.UpdateAsync(user);

    return Unit.Value;
  }
}
