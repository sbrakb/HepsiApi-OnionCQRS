using HepsiApi.Application.Bases;

namespace HepsiApi.Application.Features.Auth.Exceptions;

public class RefreshTokenShouldNotBeExpiredException : BaseException
{
  public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Tekrar giriş yapın")
  {

  }
}
