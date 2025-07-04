using MediatR;

namespace HepsiApi.Application.Features.Auth.RefreshToken;

public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
{
  public string AccessToken { get; set; }
  public string RefreshToken { get; set; }
}
