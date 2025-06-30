using System.ComponentModel;
using MediatR;

namespace HepsiApi.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
  [DefaultValue("string@str.com")]
  public string Email { get; set; }

  [DefaultValue("string")]
  public string Password { get; set; }
}
