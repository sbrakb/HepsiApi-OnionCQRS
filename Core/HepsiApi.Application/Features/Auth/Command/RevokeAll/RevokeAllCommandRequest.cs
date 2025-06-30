using HepsiApi.Application.Bases;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HepsiApi.Application.Features.Auth.Command.RevokeAll;

public class RevokeAllCommandRequest : IRequest<Unit>
{

}
public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
{
  private readonly UserManager<User> _userManager;
  public RevokeAllCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(unitOfWork, mapper, httpContextAccessor)
  {
    _userManager = userManager;
  }

  public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
  {
    List<User> users = await _userManager.Users.ToListAsync(cancellationToken);

    foreach (User user in users)
    {
      user.RefreshToken = null;
      await _userManager.UpdateAsync(user);
    }

    return Unit.Value;
  }
}
