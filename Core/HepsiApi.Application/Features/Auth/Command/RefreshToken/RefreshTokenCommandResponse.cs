using MediatR;

namespace HepsiApi.Application.Features.Auth.RefreshToken;

public class RefreshTokenCommandResponse : IRequest
{
  public string AccessToken { get; set; }
  public string RefreshToken { get; set; }
}
